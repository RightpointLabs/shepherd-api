using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using FunctionApp.Models;
using Willezone.Azure.WebJobs.Extensions.DependencyInjection;

using FunctionApp.DataContracts;
using FunctionApp.DataAccess;
using FunctionApp.Models;

namespace FunctionApp.Functions
{
    public static class CreateCommitment
    {
        [FunctionName("CreateCommitment")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "post", Route = "topics/{id}/commitments")] HttpRequest req,
            string id,
            [Inject] IRepository repository,
            ILogger log)
        {
            log.LogInformation("Create Commitment request received");

            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            CreateCommitmentRequest commitmentRequest = JsonConvert.DeserializeObject<CreateCommitmentRequest>(requestBody);

            try
            {
                Commitment commitment = new Commitment(id, commitmentRequest.PersonId, commitmentRequest.EventDate, commitmentRequest.EventType);

                await repository.AddCommitment(commitment);

                return new OkResult();
            }
            catch (ObjectAlreadyExistsException e)
            {
                return new ConflictResult();
            }
        }
    }
}