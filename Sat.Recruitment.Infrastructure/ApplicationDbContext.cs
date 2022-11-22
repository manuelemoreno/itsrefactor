#nullable disable
using Microsoft.EntityFrameworkCore;
using Sat.Recruitment.Infrastructure.Dtos;

namespace Sat.Recruitment.Infrastructure;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions options)
        : base(options) { }

    public ApplicationDbContext() { }
    public DbSet<UserDto> User { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<UserDto>().Property(x => x.OriginalMoney).HasColumnType("decimal(18,2)");
        modelBuilder.Entity<UserDto>().Property(x => x.GiftedAmount).HasColumnType("decimal(18,2)");
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        //TODO: Inject connection string to EFCore Context
        var connectionString =
            "Data Source=.;Initial Catalog=ITSRefactorDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        optionsBuilder.UseSqlServer(connectionString,
            opts => opts.CommandTimeout((int) TimeSpan.FromHours(3).TotalSeconds));
    }
}