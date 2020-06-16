using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using BFinances.Server.Invoices.Contract.Providers;
using BFinances.Server.Invoices.Contract.Response;
using BFinances.Server.Invoices.Domain.Model;
using BFinances.Server.Invoices.Infrastructure.Repository;
using Microsoft.EntityFrameworkCore;

namespace BFinances.Server.Invoices.Infrastructure.Providers
{
    public class PkwiuProvider : IPkwiuProvider
    {
        private readonly InvoicesDbContext _dbContext;

        private readonly IMapper _mapper;

        public PkwiuProvider(InvoicesDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<List<PkwiuResponse>> GetAll()
        {
            var invoices = await _dbContext.Set<Pkwiu>()
                .ToListAsync();

            var response = _mapper.Map<List<PkwiuResponse>>(invoices);

            return response;
        }
    }
}
