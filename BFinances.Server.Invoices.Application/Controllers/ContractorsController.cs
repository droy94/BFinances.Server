using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using BFinances.Server.Common.Contract.Providers;
using BFinances.Server.Common.Contract.Response;
using BFinances.Server.Invoices.Contract.Providers;
using BFinances.Server.Invoices.Contract.Response;
using Microsoft.AspNetCore.Mvc;

namespace BFinances.Server.Invoices.Application.Controllers
{
    [Route("api/[controller]")]
    public class ContractorsController : ControllerBase
    {
        private readonly IContractorProvider _contractorProvider;

        public ContractorsController(IContractorProvider contractorProvider)
        {
            _contractorProvider = contractorProvider;
        }

        [HttpGet]
        public Task<List<ContractorResponse>> GetAllContractors()
        {
            return _contractorProvider.GetAll();
        }
    }
}