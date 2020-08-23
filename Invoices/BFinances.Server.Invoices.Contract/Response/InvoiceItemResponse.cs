using System;
using System.Collections.Generic;
using System.Text;

namespace BFinances.Server.Invoices.Contract.Response
{
    public class InvoiceItemResponse
    {
        public long Id { get; set; }

        public string ServiceName { get; set; }

        public decimal NetUnitAmount { get; set; }

        public decimal NetSum { get; set; }

        public decimal VatAmountSum { get; set; }

        public decimal GrossSum { get; set; }

        public decimal VatPercent { get; set; }

        public int NumberOfUnits { get; set; }

        public string UnitName { get; set; }

        public PkwiuResponse Pkwiu { get; set; }
    }
}
