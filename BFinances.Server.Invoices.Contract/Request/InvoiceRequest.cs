using System;
using System.Collections.Generic;
using System.Text;

namespace BFinances.Server.Invoices.Contract.Request
{
    public class InvoiceRequest
    {
        // Czy tu są elementy czy id-ki zależy od działania GUI. Zrobić kawałek GUI i pewnie się okaże
        public long Id { get; set; }

        public List<InvoiceItemRequest> Items { get; set; }

        public string InvoiceNo { get; set; }

        public ContractorRequest FromContractor { get; set; }

        public ContractorRequest ForContractor { get; set; }

        public DateTime InvoiceDate { get; set; }

        public DateTime DueDate { get; set; }

        public DateTime SaleDate { get; set; }

        public int DueDays { get; set; }

        public decimal NetSum { get; set; }
    }
}
