using Microsoft.EntityFrameworkCore.Design;

namespace Sat.Recruitment.Infrastructure;

public class ApplicationContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
{
    public ApplicationDbContext CreateDbContext(string[] args)
    {
        return new ApplicationDbContext();
    }
}