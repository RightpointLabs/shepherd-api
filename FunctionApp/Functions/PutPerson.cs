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
    public static class PutPerson
    {
        [FunctionName("PutPerson")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "post", Route = "people")] HttpRequest req,
            [Inject] IRepository repository,
            ILogger log)
        {
            log.LogInformation("Put Person request received");

            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            PutPersonRequest personRequest = JsonConvert.DeserializeObject<PutPersonRequest>(requestBody);

            Person person = new Person(personRequest.Id, personRequest.Name);

            await repository.UpsertPerson(person);

            return new OkResult();
        }
    }
}
