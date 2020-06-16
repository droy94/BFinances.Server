using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using BFinances.Server.Invoices.Contract.Response;

namespace BFinances.Server.Invoices.Contract.Providers
{
    public interface IContractorProvider
    {
        Task<List<ContractorResponse>> GetAll();
    }
}
