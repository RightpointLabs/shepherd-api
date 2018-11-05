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
using System.Linq;

namespace FunctionApp.Functions
{
    public static class GetPersonById
    {
        [FunctionName("GetPersonById")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", Route = "people/{id}")] HttpRequest req,
            string id,
            [Inject] IGraphClient graphClient,
            ILogger log)
        {
            log.LogInformation($"Getting Person by ID: {id}");

            var g = graphClient.CreateTraversalSource();
            var query = g.V<PersonVertex>(id);

            log.LogInformation($"Query: {query.ToGremlinQuery()}");

            PersonVertex person = (await graphClient.QueryAsync<PersonVertex>(query)).Single();

            return new OkObjectResult(person);
        }
    }
}
