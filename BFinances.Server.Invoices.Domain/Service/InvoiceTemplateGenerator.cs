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
		                <div><h1>Wystawiono dnia {invoice.InvoiceDate.ToString()}</h1></div>
		                
		                <div class='header'><h1>Faktura nr {invoice.InvoiceNo}</h1></div>
		                <div><p>Data sprzedaży {invoice.SaleDate.ToShortDateString()}</p></div>
		                <div><p>Termin płatności {invoice.DueDate.ToShortDateString()}</p></div>
		                
		                <div class='header'><h1>Sprzedawca:</h1></div>
		                <div><p>{invoice.FromContractor.Name}</p></div>
		                <div><p>{invoice.FromContractor.Nip}</p></div>
		                <div><p>Adres Mock</p></div>
		                
		                <div class='header'><h1>Nabywca:</h1></div>
		                <div><p>{invoice.ForContractor.Name}</p></div>
		                <div><p>{invoice.ForContractor.Nip}</p></div>
		                <div><p>Adres Mock</p></div>

                        <div class='header'><h1>Pozycje:</h1></div>
                        <table align='center'>
                            <tr>
                                <th>Towar/usługa</th>
                                <th>PKWiU</th>
                                <th>Ilość</th>
                                <th>Jedn.</th>
                                <th>Cena jedn. netto</th>
                                <th>Wartość netto</th>
                                <th>Wartość brutto</th>
                                <th>Stawka VAT</th>
                                <th>Kwota VAT</th>
                            </tr>
            ");

            foreach (var item in invoice.Items)
            {
                content.Append($@"
                <tr>
                    <td>{item.ServiceName}</td>
                    <td>{item.Pkwiu.Code}</td>
                    <td>{item.NumberOfUnits}</td>
                    <td>{item.UnitName}</td>
                    <td>{item.NetUnitAmount}</td>
                    <td>{item.NetSum}</td>
                    <td>{item.GrossSum}</td>
                    <td>{item.VatPercent}%</td>
                    <td>{item.VatAmountSum}</td>
                </tr>
                ");
            }

            content.Append($@"
                </table>

                <div></div>
                <div class='header'><h1>Podsumowanie</h1></div>
                <table align='center'>
                    <tr>
                        <th></th>
                        <th>Netto</th>
                        <th>VAT</th>
                        <th>Brutto</th>
                    </tr>
                    <tr>
                        <td>Razem</td>
                        <td>{invoice.NetSum}</td>
                        <td>{invoice.VatSum}</td>
                        <td>{invoice.GrossSum}</td>
                    </tr>
                    <tr>
                        <td>Zapłacono</td>
                        <td></td>
                        <td></td>
                        <td>0,00 zł</td>
                    </tr>
                </table>
                ");

            return content.ToString();
        }
    }
}
