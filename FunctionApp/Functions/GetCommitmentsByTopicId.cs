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
using System.Collections.Generic;

namespace FunctionApp.Functions
{
    public static class GetCommitmentsByTopicId
    {
        [FunctionName("GetCommitmentsByTopicId")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", Route = "topics/{id}/commitments")] HttpRequest req,
            string id,
            [Inject] IGraphClient graphClient,
            ILogger log)
        {
            log.LogInformation($"Getting all Commitments for Topic: {id}");

            var g = graphClient.CreateTraversalSource();
            var query = g
                .V<TopicVertex>(id)
                .In(x => x.Requested);

            log.LogInformation($"Query: {query.ToGremlinQuery()}");

            IEnumerable<CommitmentEdge> commitments = await graphClient.QueryAsync<CommitmentEdge>(query);

            return new OkObjectResult(commitments);
        }
    }
}