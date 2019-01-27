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
    public static class GetTopics
    {
        [FunctionName("GetTopics")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", Route = "topics")] HttpRequest req,
            ILogger log
            )
        {
            log.LogInformation("Getting all Topics.");

            var optionsBuilder = new DbContextOptionsBuilder<Persistence.ShepherdContext>();
            optionsBuilder.UseSqlServer(Environment.GetEnvironmentVariable("ConnectionString"));

            using (var context = new Persistence.ShepherdContext(optionsBuilder.Options))
            {
                var topics = await context.Topics.ToListAsync();

                return new OkObjectResult(topics);
            }
        }
    }
}