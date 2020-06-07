using BFinances.Server.Invoices.Domain.Model;
using BFinances.Server.Invoices.Domain.Repository;
using Microsoft.EntityFrameworkCore;

namespace BFinances.Server.Invoices.Infrastructure.Repository
{
    public class InvoicesDbContext : DbContext, IInvoicesDbContext
    {
        public InvoicesDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Invoice> Invoices { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Invoice>()
                .ToTable("Invoice");

            modelBuilder.Entity<Invoice>()
                .HasKey(x => x.Id);
        }
    }
}
