
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace Sat.Recruitment.Infrastructure
{
    public class ApplicationContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
    {
        public ApplicationContextFactory() { }

     //   private readonly IConfiguration Configuration;

        /*public ApplicationContextFactory(IConfiguration configuration)
        {
            Configuration = configuration;
        }*/

        public ApplicationDbContext CreateDbContext(string[] args)
        {
            IConfiguration Configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();


            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
            optionsBuilder.UseSqlServer(Configuration.GetConnectionString("ApplicationDB"));

            return new ApplicationDbContext(optionsBuilder.Options);
        }
    }
}