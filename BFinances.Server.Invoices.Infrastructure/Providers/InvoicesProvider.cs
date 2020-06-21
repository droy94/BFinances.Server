using BFinances.Server.Invoices.Domain.Model;
using BFinances.Server.Invoices.Infrastructure.Repository;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using BFinances.Server.Invoices.Contract.Providers;
using BFinances.Server.Invoices.Contract.Request;
using BFinances.Server.Invoices.Contract.Response;
using Microsoft.EntityFrameworkCore;
using Mapper = AutoMapper.Mapper;

namespace BFinances.Server.Invoices.Infrastructure.Providers
{
    // TODO: Wydzielić z tego serwis i dodać repository jak w pracy
    public class InvoicesProvider : IInvoicesProvider
    {
        private readonly InvoicesDbContext _dbContext;

        private readonly IMapper _mapper;

        public InvoicesProvider(InvoicesDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<List<InvoiceResponse>> GetAll()
        {
            var invoices = await _dbContext.Set<Invoice>()
                .Include(x => x.FromContractor)
                .Include(x => x.ForContractor)
                .Include(x => x.Pkwiu)
                .ToListAsync();

            var response = _mapper.Map<List<InvoiceResponse>>(invoices);

            return response;
        }

        public async Task CreateInvoice(InvoiceRequest invoiceRequest)
        {
            var invoice = _mapper.Map<Invoice>(invoiceRequest);

            await _dbContext.Set<Invoice>().AddAsync(invoice);

            await _dbContext.SaveChangesAsync();
        }
    }
}
