using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BFinances.Server.Invoices.Contract.Providers;
using BFinances.Server.Invoices.Contract.Request;
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
        public Task<List<InvoiceResponse>> GetAllInvoices()
        {
            return _invoicesProvider.GetAll();
        }

        [HttpPost]
        public Task CreateInvoice([FromBody]InvoiceRequest invoice)
        {
            return _invoicesProvider.CreateInvoice(invoice);
        }

        [HttpPut("{id}")]
        public Task EditInvoice([FromBody]InvoiceRequest invoice, long id)
        {
            return _invoicesProvider.EditInvoice(invoice, id);
        }

        [HttpGet("{id}")]
        public Task<InvoiceResponse> GetInvoice(long id)
        {
            return _invoicesProvider.Get(id);
        }
    }
}
