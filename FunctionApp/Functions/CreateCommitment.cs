using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using FunctionApp.Models;
using Gremlin.Net.CosmosDb;
using Willezone.Azure.WebJobs.Extensions.DependencyInjection;

using FunctionApp.DataContracts;
using FunctionApp.DataAccess;
using FunctionApp.Models;
using FunctionApp.DataAccess.GraphSchema;

namespace FunctionApp.Functions
{
    public static class CreateCommitment
    {
        [FunctionName("CreateCommitment")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "post", Route = "topics/{id}/commitments")] HttpRequest req,
            string id,
            [Inject] IGraphClient graphClient,
            ILogger log)
        {
            log.LogInformation("Create Commitment request received");

            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            CreateCommitmentRequest commitmentRequest = JsonConvert.DeserializeObject<CreateCommitmentRequest>(requestBody);

            // save to DB
            var commitmentEdge = new CommitmentEdge
            {
                CommittedDate = DateTime.UtcNow,
                EventDate = commitmentRequest.EventDate,
                EventType = commitmentRequest.EventType
            };

            var g = graphClient.CreateTraversalSource();
            var query = g
                .V<PersonVertex>(commitmentRequest.PersonId)
                .AddE<CommitmentEdge>(commitmentEdge)
                .To(g.V<TopicVertex>(id));

            log.LogInformation($"Query: {query.ToGremlinQuery()}");

            await graphClient.QueryAsync(query);

            return new OkResult();
        }
    }
}