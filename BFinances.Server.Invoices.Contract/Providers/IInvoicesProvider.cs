using System.Collections.Generic;
using System.Threading.Tasks;
using BFinances.Server.Invoices.Contract.Request;
using BFinances.Server.Invoices.Contract.Response;

namespace BFinances.Server.Invoices.Contract.Providers
{
    public interface IInvoicesProvider
    {
        Task<List<InvoiceResponse>> GetInvoices(int month, int year);

        Task CreateInvoice(InvoiceRequest invoiceRequest);

        Task EditInvoice(InvoiceRequest invoiceRequest, long id);

        Task<InvoiceResponse> GetInvoices(long id);

        Task DeleteInvoice(long id);
    }
}