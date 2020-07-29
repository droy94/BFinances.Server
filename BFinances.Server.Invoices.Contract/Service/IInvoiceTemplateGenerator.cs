using System;
using System.Collections.Generic;
using System.Text;
using BFinances.Server.Invoices.Contract.Response;

namespace BFinances.Server.Invoices.Contract.Service
{
    public interface IInvoiceTemplateGenerator
    {
        string GetContent(InvoiceResponse invoice);
    }
}
