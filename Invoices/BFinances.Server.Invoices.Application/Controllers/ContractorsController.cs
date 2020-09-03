using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using BFinances.Server.Contractors.Contract.Providers;
using BFinances.Server.Contractors.Contract.Response;
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