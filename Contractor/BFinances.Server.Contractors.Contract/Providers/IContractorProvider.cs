using System.Collections.Generic;
using System.Threading.Tasks;
using BFinances.Server.Contractors.Contract.Response;

namespace BFinances.Server.Contractors.Contract.Providers
{
    public interface IContractorProvider
    {
        Task<List<ContractorResponse>> GetAll();
    }
}