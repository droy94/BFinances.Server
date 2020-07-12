using System;
using System.Collections.Generic;
using System.Text;
using BFinances.Server.Invoices.Common.Model;
using Microsoft.VisualBasic.CompilerServices;

namespace BFinances.Server.Invoices.Domain.Model
{
    public class InvoiceItem : Entity
    {
		public long InvoiceId { get; set; }

        public Invoice Invoice { get; set; }

        public string ServiceName { get; set; }

        public decimal NetAmount { get; set; }

        public decimal VatPercent { get; set; }

        public int NumberOfUnits { get; set; }

        public string UnitName { get; set; }
        
        public long PkwiuId { get; set; }

        public Pkwiu Pkwiu { get; set; }
    }
}
