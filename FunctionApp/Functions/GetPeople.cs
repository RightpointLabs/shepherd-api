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

using System.Collections.Generic;
using System.Linq;

namespace FunctionApp.Functions
{
    public static class GetPeople
    {
        [FunctionName("GetPeople")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", Route = "people")] HttpRequest req,
            // [Inject] IGraphClient graphClient,
            ILogger log)
        {
            log.LogInformation("Getting all People");

            var people = new List<Contracts.Models.Person>().AsEnumerable();

            return new OkObjectResult(people);
        }
    }
}