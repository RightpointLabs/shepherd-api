using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Gremlin.Net.CosmosDb;
using Willezone.Azure.WebJobs.Extensions.DependencyInjection;

using FunctionApp.DataContracts;
using FunctionApp.DataAccess;
using FunctionApp.Models;

namespace FunctionApp.Functions
{
    public static class GetCommitmentById
    {
        [FunctionName("GetCommitmentById")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", Route = "commitments/{id}")] HttpRequest req,
            string id,
            [Inject] IRepository repository,
            ILogger log)
        {
            log.LogInformation($"Getting Commitment by ID: {id}");

            try
            {
                Commitment commitment = await repository.GetCommitmentById(id);

                return new OkObjectResult(commitment);
            }
            catch (ObjectNotFoundException e)
            {
                return new NotFoundResult();
            }
        }
    }
}