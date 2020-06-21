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
    public class ContractorProvider : IContractorProvider
    {
        private readonly InvoicesDbContext _dbContext;

        private readonly IMapper _mapper;

        public ContractorProvider(InvoicesDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<List<ContractorResponse>> GetAll()
        {
            var contractors = await _dbContext.Set<Contractor>()
                .ToListAsync();

            var response = _mapper.Map<List<ContractorResponse>>(contractors);

            return response;
        }
    }
}
