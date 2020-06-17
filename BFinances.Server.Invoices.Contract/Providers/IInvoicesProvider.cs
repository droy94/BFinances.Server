using System.Collections.Generic;
using System.Threading.Tasks;
using BFinances.Server.Invoices.Contract.Request;
using BFinances.Server.Invoices.Contract.Response;

namespace BFinances.Server.Invoices.Contract.Providers
{
    public interface IInvoicesProvider
    {
        Task<List<InvoiceResponse>> GetAll();

        Task CreateInvoice(InvoiceRequest invoiceRequest);
    }
}
