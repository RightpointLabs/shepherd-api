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

using Microsoft.EntityFrameworkCore;

namespace FunctionApp.Functions
{
    public static class GetCommitmentById
    {
        [FunctionName("GetCommitmentById")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", Route = "commitments/{id}")] HttpRequest req,
            string id,
            ILogger log
            )
        {
            log.LogInformation($"Getting Commitment by ID: {id}");

            var optionsBuilder = new DbContextOptionsBuilder<Shared.Persistence.ShepherdContext>();
            optionsBuilder.UseSqlServer(Environment.GetEnvironmentVariable("ConnectionString"));

            using (var context = new Shared.Persistence.ShepherdContext(optionsBuilder.Options))
            {
                var commitment = await context.Commitments.FindAsync(new Guid(id));

                return new OkObjectResult(commitment);
            }
        }
    }
}