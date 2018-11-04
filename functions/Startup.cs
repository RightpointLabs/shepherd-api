using functions;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Willezone.Azure.WebJobs.Extensions.DependencyInjection;

[assembly: WebJobsStartup(typeof(Startup))]
namespace functions
{
    internal class Startup : IWebJobsStartup
    {
        public void Configure(IWebJobsBuilder builder) =>
            builder.AddDependencyInjection(ConfigureServices);

        private void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<IRepository, MockRepository>();
        }
    }
}