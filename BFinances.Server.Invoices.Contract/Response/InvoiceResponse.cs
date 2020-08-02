using System;
using System.Collections.Generic;
using System.Text;
using BFinances.Server.Common.Contract.Response;

namespace BFinances.Server.Invoices.Contract.Response
{
    public class InvoiceResponse
    {
        public long Id { get; set; }

        public List<InvoiceItemResponse> Items { get; set; }

        public string InvoiceNo { get; set; }

        public ContractorResponse FromContractor { get; set; }

        public ContractorResponse ForContractor { get; set; }

        public DateTime InvoiceDate { get; set; }

        public DateTime DueDate { get; set; }

        public DateTime SaleDate { get; set; }

        public int DueDays { get; set; }

        public decimal VatSum { get; set; }

        public decimal NetSum { get; set; }

        public decimal GrossSum { get; set; }
    }
}