using System.Collections.Generic;
using System.Threading.Tasks;
using BFinances.Server.Invoices.Contract.Providers;
using BFinances.Server.Invoices.Contract.Response;
using Microsoft.AspNetCore.Mvc;

namespace BFinances.Server.Invoices.Application.Controllers
{
    [Route("api/[controller]")]
    public class InvoicesController : ControllerBase
    {
        private readonly IInvoicesProvider _invoicesProvider;

        public InvoicesController(IInvoicesProvider invoicesProvider)
        {
            _invoicesProvider = invoicesProvider;
        }

        [HttpGet]
        public Task<List<InvoiceResponse>> GetAvailableCountries()
        {
            return _invoicesProvider.GetAll();
        }
    }
}
