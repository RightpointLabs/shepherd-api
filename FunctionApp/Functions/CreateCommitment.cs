using System;
using System.Collections.Generic;
using System.IO;
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
    public static class CreateCommitment
    {
        [FunctionName("CreateCommitment")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "post", Route = "topics/{id}/commitments")] HttpRequest req,
            string id,
            ILogger log)
        {
            log.LogInformation("Create Commitment request received");

            var requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            var commitmentRequest = JsonConvert.DeserializeObject<Contracts.CreateCommitmentRequest>(requestBody);

            var commitment = new Contracts.Models.Commitment();

            return new OkObjectResult(commitment);
        }
    }
}