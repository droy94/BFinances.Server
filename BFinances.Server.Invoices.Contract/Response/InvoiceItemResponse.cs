using System;
using System.Collections.Generic;
using System.Text;

namespace BFinances.Server.Invoices.Contract.Response
{
    public class InvoiceItemResponse
    {
        public long Id { get; set; }

        public InvoiceResponse Invoice { get; set; }

        public decimal NetAmount { get; set; }

        public decimal VatPercent { get; set; }

        public int NumberOfUnits { get; set; }

        public string UnitName { get; set; }

        public PkwiuResponse Pkwiu { get; set; }
    }
}
