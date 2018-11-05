using FunctionApp;
using FunctionApp.DataAccess;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Willezone.Azure.WebJobs.Extensions.DependencyInjection;
using Gremlin.Net.CosmosDb;

[assembly: WebJobsStartup(typeof(Startup))]
namespace FunctionApp
{
    internal class Startup : IWebJobsStartup
    {
        public void Configure(IWebJobsBuilder builder) =>
            builder.AddDependencyInjection(ConfigureServices);

        private void ConfigureServices(IServiceCollection services)
        {
            IGraphClient graphClient = new GraphClient("shepherd-local.gremlin.cosmosdb.azure.com", "shepherd", "shepherd", "rjfqIQKhqBcpMarT0alwQJdpgVQopBDzZi1IZpso2v1z0A3fTEKyUOIZPdaQ10XnoKNFpLgrpmw4wlHsdFb76A==");
            services.AddSingleton(graphClient);
        }
    }
}