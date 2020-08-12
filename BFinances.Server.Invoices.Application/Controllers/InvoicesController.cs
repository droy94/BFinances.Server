using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BFinances.Server.Invoices.Contract.Providers;
using BFinances.Server.Invoices.Contract.Request;
using BFinances.Server.Invoices.Contract.Response;
using BFinances.Server.Invoices.Contract.Service;
using Microsoft.AspNetCore.Mvc;

namespace BFinances.Server.Invoices.Application.Controllers
{
    [Route("api/[controller]")]
    public class InvoicesController : ControllerBase
    {
        private readonly IInvoicesProvider _invoicesProvider;
        private readonly IInvoicePdfService _invoicePdfService;

        public InvoicesController(IInvoicesProvider invoicesProvider, IInvoicePdfService invoicePdfService)
        {
            _invoicesProvider = invoicesProvider;
            _invoicePdfService = invoicePdfService;
        }

        [HttpGet]
        public Task<List<InvoiceResponse>> GetInvoices([FromQuery] int month, [FromQuery] int year)
        {
            return _invoicesProvider.Get(month, year);
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

        [HttpDelete("{id}")]
        public Task DeleteInvoice(long id)
        {
            return _invoicesProvider.DeleteInvoice(id);
        }

        [HttpGet("generate/{id}")]
        public async Task<IActionResult> GeneratePdf(long id)
        {
            var file = await _invoicePdfService.Generate(id);

            return File(file, "application/pdf", "faktura");
        }
    }
}