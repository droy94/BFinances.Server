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
		                <div class='header'><h1>Wystawiono dnia {invoice.InvoiceDate.ToString()}</h1></div>
		                
		                <div class='header'><h1>Faktura nr {invoice.InvoiceNo}</h1></div>
		                <div class='header'><p>Data sprzedaży {invoice.SaleDate.ToString()}</p></div>
		                <div class='header'><p>Termin płatności {invoice.DueDate.ToString()}</p></div>
		                
		                <div class='header'><h1>Sprzedawca:</h1></div>
		                <div class='header'><p>{invoice.FromContractor.Name}</p></div>
		                <div class='header'><p>{invoice.FromContractor.Nip}</p></div>
		                <div class='header'><p>Adres Mock</p></div>
		                
		                <div class='header'><h1>Nabywca:</h1></div>
		                <div class='header'><p>{invoice.ForContractor.Name}</p></div>
		                <div class='header'><p>{invoice.ForContractor.Nip}</p></div>
		                <div class='header'><p>Adres Mock</p></div>

                        <div class='header'><h1>Pozycje:</h1></div>
                            <tr>
<th></th>
<th>Towar/usługa</th>
<th>PKWiU</th>
<th>Ilość</th>
<th>Jedn.</th>
<th>Cena jedn. netto</th>
<th>Wartość netto</th>
<th>Stawka VAT</th>
</tr>
            ");

            foreach (var item in invoice.Items)
            {
                content.Append($@"
                    
            ");
            }

            return content.ToString();
        }
    }
}
