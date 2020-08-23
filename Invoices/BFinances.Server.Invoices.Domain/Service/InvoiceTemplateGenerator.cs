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
		                <div><p>Wystawiono dnia {invoice.InvoiceDate.ToShortDateString()}</p></div>

                        <div>
	                        <div id='invoice-no'>
		                        <h1>Faktura nr {invoice.InvoiceNo}</h1>
		                        <p>Data sprzedaży: {invoice.SaleDate.ToShortDateString()}</p>
		                        <p>Termin płatności: {invoice.DueDate.ToShortDateString()}</p>
	                        </div>

                            <div>
	                            <div class='left-div'>
		                            <h1>Sprzedawca:</h1>
		                            <p>{invoice.FromContractor.Name}</p>
		                            <p>{invoice.FromContractor.Nip}</p>
		                            <p>Jana Pawła II</p>
                                    <p>01-295 Warszawa</p>
	                            </div>

	                            <div class='right-div'>
		                            <h1>Nabywca:</h1>
		                            <p>{invoice.ForContractor.Name}</p>
		                            <p>{invoice.ForContractor.Nip}</p>
		                            <p>Ordona 35</p>
                                    <p>01-321 Warszawa</p>
	                            </div>
                            </div>
                        </div>

                        <div class='clear'><h1>Pozycje:</h1></div>
                        <table>
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
                    <td>{item.NetUnitAmount:C}</td>
                    <td>{item.NetSum:C}</td>
                    <td>{item.GrossSum:C}</td>
                    <td>{item.VatPercent}%</td>
                    <td>{item.VatAmountSum:C}</td>
                </tr>
                ");
            }

            content.Append($@"
                </table>

                <div></div>
                <div><h1>Podsumowanie</h1></div>
                <table>
                    <tr>
                        <th></th>
                        <th>Netto</th>
                        <th>VAT</th>
                        <th>Brutto</th>
                    </tr>
                    <tr>
                        <td>Razem</td>
                        <td>{invoice.NetSum:C}</td>
                        <td>{invoice.VatSum:C}</td>
                        <td>{invoice.GrossSum:C}</td>
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