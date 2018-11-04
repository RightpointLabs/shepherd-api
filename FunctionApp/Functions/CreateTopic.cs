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
using FunctionApp.DataAccess;
using FunctionApp.Models;

namespace FunctionApp.Functions
{
    public static class CreateTopic
    {
        [FunctionName("CreateTopic")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "post", Route = "topics")] HttpRequest req,
            [Inject] IRepository repository,
            ILogger log)
        {
            log.LogInformation("Create Topic request received");

            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            CreateTopicRequest topicRequest = JsonConvert.DeserializeObject<CreateTopicRequest>(requestBody);

            Topic topic = new Topic(topicRequest.Title, topicRequest.SuccessCriteria, topicRequest.Requestor);

            await repository.AddTopic(topic);

            return new OkResult();
        }
    }
}
