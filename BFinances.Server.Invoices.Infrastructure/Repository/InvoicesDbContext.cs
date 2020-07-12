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

        public DbSet<Contractor> Contractors { get; set; }

        public DbSet<Pkwiu> Pkwiu { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Invoice>()
                .ToTable("Invoices")
                .HasKey(x => x.Id);

            modelBuilder.Entity<Pkwiu>()
                .ToTable("Pkwiu")
                .HasKey(x => x.Id);

            modelBuilder.Entity<Contractor>()
                .ToTable("Contractors")
                .HasKey(x => x.Id);

            modelBuilder.Entity<InvoiceItem>()
                .ToTable("InvoiceItems")
                .HasKey(x => x.Id);
        }
    }
}
