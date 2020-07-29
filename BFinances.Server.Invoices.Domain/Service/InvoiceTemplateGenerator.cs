using System;
using System.Collections.Generic;
using System.Text;
using BFinances.Server.Invoices.Contract.Response;
using BFinances.Server.Invoices.Contract.Service;
using BFinances.Server.Invoices.Domain.Model;

namespace BFinances.Server.Invoices.Domain.Service
{
    public class InvoiceTemplateGenerator : IInvoiceTemplateGenerator
    {
        public string GetContent(InvoiceResponse invoice)
        {
            var content = new StringBuilder();

            content.Append($@"
                <html>
	                <head></head>
	                <body>
		                <div class='header'><h1>{invoice.InvoiceNo}</h1></div>
                    </body>
                </html>
            ");

            return content.ToString();
        }
    }
}
