using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace FunctionApp.Functions
{
    public static class GetCommitmentsByTopicId
    {
        [FunctionName("GetCommitmentsByTopicId")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", Route = "topics/{id}/commitments")] HttpRequest req,
            string id,
            ILogger log)
        {
            log.LogInformation($"Getting all Commitments for Topic: {id}");

            var commitments = new List<Contracts.Models.Commitment>().AsEnumerable();

            return new OkObjectResult(commitments);
        }
    }
}