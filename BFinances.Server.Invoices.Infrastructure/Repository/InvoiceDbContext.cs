using BFinances.Server.Invoices.Domain.Model;
using BFinances.Server.Invoices.Domain.Repository;
using Microsoft.EntityFrameworkCore;

namespace BFinances.Server.Invoices.Infrastructure.Repository
{
    public class InvoiceDbContext : DbContext, IInvoiceDbContext
    {
        public InvoiceDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Invoice> Invoices { get; set; }
    }
}
