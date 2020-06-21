using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using BFinances.Server.Invoices.Contract.Providers;
using BFinances.Server.Invoices.Contract.Response;
using Microsoft.AspNetCore.Mvc;

namespace BFinances.Server.Invoices.Application.Controllers
{
    [Route("api/[controller]")]
    public class PkwiuController : ControllerBase
    {
        private readonly IPkwiuProvider _pkwiuProvider;

        public PkwiuController(IPkwiuProvider pkwiuProvider)
        {
            _pkwiuProvider = pkwiuProvider;
        }

        [HttpGet]
        public Task<List<PkwiuResponse>> GetAllPkwiu()
        {
            return _pkwiuProvider.GetAll();
        }
    }
}
