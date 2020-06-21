using System;
using System.Collections.Generic;
using System.Text;

namespace BFinances.Server.Invoices.Contract.Request
{
    public class InvoiceRequest
    {
        public string Number { get; set; }

        public long FromContractorId { get; set; }

        public ContractorRequest ForContractor { get; set; }

        public DateTime InvoiceDate { get; set; }

        public DateTime DueDate { get; set; }

        public DateTime SaleDate { get; set; }

        public decimal NetAmount { get; set; }

        public decimal VatPercent { get; set; }

        public int NumberOfUnits { get; set; }

        public string UnitName { get; set; }

        public PkwiuRequest Pkwiu { get; set; }
    }
}
