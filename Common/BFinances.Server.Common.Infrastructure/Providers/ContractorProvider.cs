using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using BFinances.Server.Common.Contract.Providers;
using BFinances.Server.Common.Contract.Response;
using BFinances.Server.Common.Domain.Model;
using BFinances.Server.Common.Infrastructure.Repository;
using Microsoft.EntityFrameworkCore;

namespace BFinances.Server.Common.Infrastructure.Providers
{
    public class ContractorProvider : IContractorProvider
    {
        private readonly CommonDbContext _dbContext;

        private readonly IMapper _mapper;

        public ContractorProvider(CommonDbContext dbContext, IMapper mapper)
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