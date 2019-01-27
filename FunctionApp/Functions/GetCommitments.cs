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
    public static class GetCommitments
    {
        [FunctionName("GetCommitments")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", Route = "commitments")] HttpRequest req,
            ILogger log
            )
        {
            log.LogInformation("Getting all Commitments");

            var optionsBuilder = new DbContextOptionsBuilder<Database.Persistence.ShepherdContext>();
            optionsBuilder.UseSqlServer(Environment.GetEnvironmentVariable("ConnectionString"));

            using (var context = new Database.Persistence.ShepherdContext(optionsBuilder.Options))
            {
                var commitments = await context.Commitments.ToListAsync();

                return new OkObjectResult(commitments);
            }
        }
    }
}