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
    public static class GetTopicById
    {
        [FunctionName("GetTopicById")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", Route = "topics/{id}")] HttpRequest req,
            string id,
            ILogger log
            )
        {
            log.LogInformation($"Getting Topic by ID: {id}");

            var optionsBuilder = new DbContextOptionsBuilder<Database.Persistence.ShepherdContext>();
            optionsBuilder.UseSqlServer(Environment.GetEnvironmentVariable("ConnectionString"));

            using (var context = new Database.Persistence.ShepherdContext(optionsBuilder.Options))
            {
                var topic = await context.Topics.FindAsync(new Guid(id));

                return new OkObjectResult(topic);
            }
        }
    }
}