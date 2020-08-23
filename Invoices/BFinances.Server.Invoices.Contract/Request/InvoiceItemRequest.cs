using System;
using System.Collections.Generic;
using System.Text;

namespace BFinances.Server.Invoices.Contract.Request
{
    public class InvoiceItemRequest
    {
        public long Id { get; set; }

        public string ServiceName { get; set; }

        public decimal NetUnitAmount { get; set; }

        public decimal NetSum => NetUnitAmount * NumberOfUnits;

        public decimal VatAmountSum => NetSum * VatPercent / 100;

        public decimal GrossSum => NetSum + VatAmountSum;

        public decimal VatPercent { get; set; }

        public int NumberOfUnits { get; set; }

        public string UnitName { get; set; }

        public PkwiuRequest Pkwiu { get; set; }
    }
}
