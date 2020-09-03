using BFinances.Server.Common.Domain.Model;
using BFinances.Server.Contractors.Domain.Model;
using BFinances.Server.Expenses.Domain.Model;
using Microsoft.EntityFrameworkCore;

namespace BFinances.Server.Expenses.Infrastructure.Repository
{
    public class ExpensesDbContext : DbContext
    {
        public ExpensesDbContext(DbContextOptions<ExpensesDbContext> options) : base(options)
        {
        }

        public DbSet<Expense> Expenses { get; set; }

        public DbSet<Contractor> Contractors { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Expense>()
                .ToTable("Expenses")
                .HasKey(x => x.Id);

            modelBuilder.Entity<Contractor>()
                .ToTable("Contractors")
                .HasKey(x => x.Id);
        }
    }
}