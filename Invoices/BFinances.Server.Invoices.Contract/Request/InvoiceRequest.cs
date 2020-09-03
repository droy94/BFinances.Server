using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BFinances.Server.Contractors.Contract.Request;

namespace BFinances.Server.Invoices.Contract.Request
{
    public class InvoiceRequest
    {
        public long Id { get; set; }

        public List<InvoiceItemRequest> Items { get; set; }

        public string InvoiceNo { get; set; }

        public ContractorRequest FromContractor { get; set; }

        public ContractorRequest ForContractor { get; set; }

        public DateTime InvoiceDate { get; set; }

        public DateTime DueDate { get; set; }

        public DateTime SaleDate { get; set; }

        public int DueDays { get; set; }

        public decimal VatSum => Items.Sum(x => x.VatAmountSum);

        public decimal NetSum => Items.Sum(x => x.NetSum);

        public decimal GrossSum => NetSum + Items.Sum(x => x.VatAmountSum);
    }
}