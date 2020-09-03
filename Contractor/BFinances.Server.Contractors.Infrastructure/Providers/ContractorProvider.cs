using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using BFinances.Server.Contractors.Contract.Providers;
using BFinances.Server.Contractors.Contract.Response;
using BFinances.Server.Contractors.Infrastructure.Repository;
using Microsoft.EntityFrameworkCore;

namespace BFinances.Server.Contractors.Infrastructure.Providers
{
    public class ContractorProvider : IContractorProvider
    {
        private readonly ContractorDbContext _dbContext;

        private readonly IMapper _mapper;

        public ContractorProvider(ContractorDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<List<ContractorResponse>> GetAll()
        {
            var contractors = await _dbContext.Set<Domain.Model.Contractor>()
                .ToListAsync();

            var response = _mapper.Map<List<ContractorResponse>>(contractors);

            return response;
        }
    }
}