using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Gremlin.Net.CosmosDb;
using Willezone.Azure.WebJobs.Extensions.DependencyInjection;

using FunctionApp.DataContracts;
using FunctionApp.DataAccess;
using FunctionApp.DataAccess.GraphSchema;

namespace FunctionApp.Functions
{
    public static class CreateTopic
    {
        [FunctionName("CreateTopic")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "post", Route = "topics")] HttpRequest req,
            [Inject] IGraphClient graphClient,
            ILogger log)
        {
            log.LogInformation("Create Topic request received");

            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            CreateTopicRequest topicRequest = JsonConvert.DeserializeObject<CreateTopicRequest>(requestBody);

            // save to DB
            var topicVertex = new TopicVertex
            {
                Title = topicRequest.Title,
                SuccessCriteria = topicRequest.SuccessCriteria
            };
            var requestEdge = new RequestEdge
            {
                RequestedDate = DateTime.UtcNow
            };

            var g = graphClient.CreateTraversalSource();
            var query = g
                .V<PersonVertex>(topicRequest.PersonId)
                .AddE<RequestEdge>(requestEdge)
                .To(g.AddV<TopicVertex>(topicVertex));

            log.LogInformation($"Query: {query.ToGremlinQuery()}");

            await graphClient.QueryAsync(query);

            return new OkResult();
        }
    }
}