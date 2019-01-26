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

namespace FunctionApp.Functions
{
    public static class GetCommitmentById
    {
        [FunctionName("GetCommitmentById")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", Route = "commitments/{id}")] HttpRequest req,
            string id,
            // [Inject] IGraphClient graphClient,
            ILogger log)
        {
            log.LogInformation($"Getting Commitment by ID: {id}");

            var commitment = new Contracts.Models.Commitment();

            return new OkObjectResult(commitment);
        }
    }
}