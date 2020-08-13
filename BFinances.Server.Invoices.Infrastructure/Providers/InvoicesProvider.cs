using BFinances.Server.Invoices.Domain.Model;
using BFinances.Server.Invoices.Infrastructure.Repository;
using System.Collections.Generic;
using System.Linq;
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

        public async Task<List<InvoiceResponse>> GetInvoices(int month, int year)
        {
            var invoices = await _dbContext.Set<Invoice>()
                .Where(x => x.InvoiceDate.Month == month && x.InvoiceDate.Year == year)
                .Include(x => x.FromContractor)
                .Include(x => x.ForContractor)
                .Include(x => x.Items)
                .ThenInclude(x => x.Pkwiu)
                .OrderByDescending(x => x.InvoiceDate)
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

        // id po to, żeby nie zmieniać id modelu przy mapowaniu
        public async Task EditInvoice(InvoiceRequest invoiceRequest, long id)
        {
            var invoiceToEdit = await _dbContext.Set<Invoice>()
                .Include(x => x.Items)
                .Where(x => x.Id == id)
                .FirstOrDefaultAsync();

            _mapper.Map(invoiceRequest, invoiceToEdit);

            await _dbContext.SaveChangesAsync();
        }

        public async Task<InvoiceResponse> GetInvoices(long id)
        {
            var invoice = await _dbContext.Set<Invoice>()
                .Include(x => x.FromContractor)
                .Include(x => x.ForContractor)
                .Include(x => x.Items)
                .ThenInclude(x => x.Pkwiu)
                .Where(x => x.Id == id)
                .FirstOrDefaultAsync();

            var response = _mapper.Map<InvoiceResponse>(invoice);

            return response;
        }

        public async Task DeleteInvoice(long id)
        {
            var invoice = await _dbContext.Set<Invoice>()
                .Include(x => x.Items)
                .Where(x => x.Id == id)
                .FirstOrDefaultAsync();

            _dbContext.Set<Invoice>().Remove(invoice);

            await _dbContext.SaveChangesAsync();
        }
    }
}