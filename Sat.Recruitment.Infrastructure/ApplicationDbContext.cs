using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Sat.Recruitment.Domain.Configuration;
using Sat.Recruitment.Infrastructure.Dtos;

#nullable disable

namespace Sat.Recruitment.Infrastructure
{
    public class ApplicationDbContext : DbContext
    {
        private readonly IConfiguration _configuration;
      //  private readonly ApplicationConnectionString _dbConnectionStrings = new();

        /*public ApplicationDbContext(IOptions<ApplicationConnectionString> dbConnectionStrings)
            => _dbConnectionStrings = dbConnectionStrings.Value;*/
        public ApplicationDbContext(DbContextOptions options)
            : base(options)
        {
        }

        public ApplicationDbContext()
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)

        {
            modelBuilder.Entity<UserDto>().Property(x => x.OriginalMoney).HasColumnType("decimal(18,2)");
            modelBuilder.Entity<UserDto>().Property(x => x.GiftedAmount).HasColumnType("decimal(18,2)");

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connectionString =
                "Data Source=.;Initial Catalog=ITSRefactorDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            optionsBuilder.UseSqlServer(connectionString,
                opts => opts.CommandTimeout((int)TimeSpan.FromHours(3).TotalSeconds));
        }

        public DbSet<UserDto> User { get; set; }
    }

}
