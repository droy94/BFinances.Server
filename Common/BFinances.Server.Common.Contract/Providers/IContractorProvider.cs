using System.Collections.Generic;
using System.Threading.Tasks;
using BFinances.Server.Common.Contract.Response;

namespace BFinances.Server.Common.Contract.Providers
{
    public interface IContractorProvider
    {
        Task<List<ContractorResponse>> GetAll();
    }
}