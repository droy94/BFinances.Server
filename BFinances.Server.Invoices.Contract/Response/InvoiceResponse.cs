using System;
using System.Collections.Generic;
using System.Text;

namespace BFinances.Server.Invoices.Contract.Response
{
    public class InvoiceResponse
    {
        public long Id { get; set; }

        public string Number { get; set; }

        public ContractorResponse FromContractor { get; set; }

        public ContractorResponse ForContractor { get; set; }

        public DateTime InvoiceDate { get; set; }

        public DateTime DueDate { get; set; }

        public DateTime SaleDate { get; set; }

        public decimal NetAmount { get; set; }

        public decimal VatPercent { get; set; }

        public int NumberOfUnits { get; set; }

        public string UnitName { get; set; }

        public PkwiuResponse Pkwiu { get; set; }
    }
}
