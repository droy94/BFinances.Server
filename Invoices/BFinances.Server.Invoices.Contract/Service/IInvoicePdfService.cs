using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BFinances.Server.Invoices.Contract.Service
{
    public interface IInvoicePdfService
    {
        Task<byte[]> Generate(long invoiceId);
    }
}
