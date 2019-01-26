using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Willezone.Azure.WebJobs.Extensions.DependencyInjection;

using FunctionApp.DataContracts;
using FunctionApp.Models;

namespace FunctionApp.Functions
{
    public static class CreateCommitment
    {
        [FunctionName("CreateCommitment")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "post", Route = "topics/{id}/commitments")] HttpRequest req,
            string id,
            // [Inject] IGraphClient graphClient,
            ILogger log)
        {
            log.LogInformation("Create Commitment request received");

            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            CreateCommitmentRequest commitmentRequest = JsonConvert.DeserializeObject<CreateCommitmentRequest>(requestBody);

            Commitment commitment = new Commitment();

            return new OkObjectResult(commitment);
        }
    }
}