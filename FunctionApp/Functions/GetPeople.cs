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
    public static class GetPeople
    {
        [FunctionName("GetPeople")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", Route = "people")] HttpRequest req,
            [Inject] IGraphClient graphClient,
            ILogger log)
        {
            log.LogInformation("Getting all People");

            var g = graphClient.CreateTraversalSource();
            var query = g.V<PersonVertex>();

            log.LogInformation($"Query: {query.ToGremlinQuery()}");

            var result = await graphClient.QueryAsync<PersonVertex>(query);

            return new OkObjectResult(result);
        }
    }
}