using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Willezone.Azure.WebJobs.Extensions.DependencyInjection;

using FunctionApp.DataContracts;
using System.Collections.Generic;
using FunctionApp.Models;
using System.Linq;

namespace FunctionApp.Functions
{
    public static class GetCommitmentsByTopicId
    {
        [FunctionName("GetCommitmentsByTopicId")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", Route = "topics/{id}/commitments")] HttpRequest req,
            string id,
            // [Inject] IGraphClient graphClient,
            ILogger log)
        {
            log.LogInformation($"Getting all Commitments for Topic: {id}");

            IEnumerable<Commitment> commitments = new List<Commitment>().AsEnumerable();

            return new OkObjectResult(commitments);
        }
    }
}