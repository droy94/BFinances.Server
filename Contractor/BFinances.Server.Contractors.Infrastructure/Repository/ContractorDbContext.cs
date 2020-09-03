using Microsoft.EntityFrameworkCore;

namespace BFinances.Server.Contractors.Infrastructure.Repository
{
    public class ContractorDbContext : DbContext
    {
        public DbSet<Domain.Model.Contractor> Contractors { get; set; }

        public ContractorDbContext(DbContextOptions<ContractorDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Domain.Model.Contractor>()
                .ToTable("Contractors")
                .HasKey(x => x.Id);
        }
    }
}