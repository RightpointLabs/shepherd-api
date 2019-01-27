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
    public static class GetCommitmentsByTopicId
    {
        [FunctionName("GetCommitmentsByTopicId")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", Route = "topics/{id}/commitments")] HttpRequest req,
            string id,
            ILogger log
            )
        {
            log.LogInformation($"Getting all Commitments for Topic: {id}");

            var optionsBuilder = new DbContextOptionsBuilder<Persistence.ShepherdContext>();
            optionsBuilder.UseSqlServer(Environment.GetEnvironmentVariable("ConnectionString"));

            using (var context = new Persistence.ShepherdContext(optionsBuilder.Options))
            {
                var topic = await context.Topics.Include(x => x.Commitments).SingleOrDefaultAsync(x => x.Id == new Guid(id));

                if(topic == null) return new NotFoundResult();

                var commitments = topic.Commitments.ToList();

                return new OkObjectResult(commitments);
            }
        }
    }
}