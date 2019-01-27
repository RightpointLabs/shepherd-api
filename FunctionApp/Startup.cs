using System;
using FunctionApp;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

[assembly: WebJobsStartup(typeof(Startup))]
namespace FunctionApp
{
    internal class Startup : IWebJobsStartup
    {
        public void Configure(IWebJobsBuilder builder) { }

        private void ConfigureServices(IServiceCollection services)
        {
            // register EF
            var connection = Environment.GetEnvironmentVariable("ConnectionString", EnvironmentVariableTarget.Process); ;
            services.AddDbContext<Shared.Persistence.ShepherdContext>(options => options.UseSqlServer(connection));
        }
    }
}