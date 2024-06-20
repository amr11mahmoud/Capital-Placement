using CapitalPlacement.Models.Applications;
using CapitalPlacement.Models.Candidates;
using CapitalPlacement.Models.Programs;
using CapitalPlacement.Models.Questions;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;


namespace CapitalPlacement.DataBase
{
    public class CapitalDbContext: DbContext
    {
        public CapitalDbContext(DbContextOptions<CapitalDbContext> options) : base(options)
        {
        }
        public DbSet<CapitalProgram> Programs { get; set; }
        public DbSet<Application> Applications { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            
            builder.Entity<CapitalProgram>(entity =>
            {
                entity.ToContainer("Programs");
                entity.HasKey(p => p.Id);
            });
            
            builder.Entity<Application>(entity =>
            {
                entity.ToContainer("Applications");
                entity.HasKey(p => p.Id);
            });
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                IConfigurationRoot configuration = new ConfigurationBuilder()
                   .SetBasePath(Directory.GetCurrentDirectory())
                   .AddJsonFile("appsettings.Development.json")
                   .Build();

                optionsBuilder.UseCosmos(
                    configuration["CosmosDb:PrimaryConnectionString"],
                    configuration["CosmosDb:Database"]
                );
            }

            base.OnConfiguring(optionsBuilder);
        }
    }
}
