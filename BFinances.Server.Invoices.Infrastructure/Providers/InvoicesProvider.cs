using BFinances.Server.Invoices.Domain.Model;
using BFinances.Server.Invoices.Infrastructure.Repository;
using System.Collections.Generic;
using System.Threading.Tasks;
using BFinances.Server.Invoices.Contract.Providers;
using BFinances.Server.Invoices.Contract.Response;
using Microsoft.EntityFrameworkCore;

namespace BFinances.Server.Invoices.Infrastructure.Providers
{
    public class InvoicesProvider : IInvoicesProvider
    {
        private readonly InvoicesDbContext _dbContext;

        public InvoicesProvider(InvoicesDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<InvoiceResponse>> GetAll()
        {
            var invoices = await _dbContext.Set<Invoice>().ToListAsync();

            var response = new List<InvoiceResponse>();

            // TODO: Use mapper
            foreach (var invoice in invoices)
            {
                response.Add(new InvoiceResponse { Number = invoice.Number, Id = invoice.Id });
            }

            return response;
        }
    }
}
