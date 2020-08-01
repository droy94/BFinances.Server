using System;
using System.Collections.Generic;
using BFinances.Server.Common.Domain.Model;
using Microsoft.VisualBasic;

namespace BFinances.Server.Invoices.Domain.Model
{
    public class Invoice : Entity
    {
        public List<InvoiceItem> Items { get; set; }

        public string InvoiceNo { get; set; }

        public long FromContractorId { get; set; }

        public Contractor FromContractor { get; set; }

        public long ForContractorId { get; set; }

        public Contractor ForContractor { get; set; }

        public DateTime InvoiceDate { get; set; }

        public DateTime DueDate { get; set; }

        public DateTime SaleDate { get; set; }

        public int DueDays { get; set; }

        public decimal VatSum { get; set; }

        public decimal NetSum { get; set; }

        public decimal GrossSum { get; set; }
    }
}