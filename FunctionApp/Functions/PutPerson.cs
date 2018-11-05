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
    public static class PutPerson
    {
        [FunctionName("PutPerson")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "put", Route = "people")] HttpRequest req,
            [Inject] IGraphClient graphClient,
            ILogger log)
        {
            log.LogInformation("Put Person request received");

            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            PutPersonRequest personRequest = JsonConvert.DeserializeObject<PutPersonRequest>(requestBody);

            PersonVertex person = new PersonVertex
            {
                ExternalId = personRequest.ExternalId,
                Name = personRequest.Name
            };

            var g = graphClient.CreateTraversalSource();
            var query = g.AddV<PersonVertex>(person);

            var response = await graphClient.QueryAsync<PersonVertex>(query);

            return new OkObjectResult(response);
        }
    }
}