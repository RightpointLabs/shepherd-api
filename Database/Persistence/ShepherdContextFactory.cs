using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace Database.Persistence
{
    public class ShepherdContextFactory : IDesignTimeDbContextFactory<ShepherdContext>
    {
        public ShepherdContext CreateDbContext(string[] args)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var optionsBuilder = new DbContextOptionsBuilder<ShepherdContext>();
            optionsBuilder.UseSqlServer(configuration["connectionString"]);

            return new ShepherdContext(optionsBuilder.Options);
        }
    }
}