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
    public static class CreateTopic
    {
        [FunctionName("CreateTopic")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "post", Route = "topics")] HttpRequest req,
            // [Inject] IGraphClient graphClient,
            ILogger log)
        {
            log.LogInformation("Create Topic request received");

            var requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            var topicRequest = JsonConvert.DeserializeObject<Contracts.CreateTopicRequest>(requestBody);

            var topic = new Contracts.Models.Topic();

            return new OkObjectResult(topic);
        }
    }
}