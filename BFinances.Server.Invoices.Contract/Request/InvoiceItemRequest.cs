using System;
using System.Collections.Generic;
using System.Text;

namespace BFinances.Server.Invoices.Contract.Request
{
    public class InvoiceItemRequest
    {
        public InvoiceRequest Invoice { get; set; }

        public string ServiceName { get; set; }

        public decimal NetAmount { get; set; }

        public decimal VatPercent { get; set; }

        public int NumberOfUnits { get; set; }

        public string UnitName { get; set; }

        public long PkwiuId { get; set; }
    }
}
