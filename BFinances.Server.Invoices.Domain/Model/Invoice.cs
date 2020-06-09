using System;
using BFinances.Server.Invoices.Common.Model;
using Microsoft.VisualBasic;

namespace BFinances.Server.Invoices.Domain.Model
{
    public class Invoice : Entity
    {
        public string Number { get; set; }

        public long FromContractorId { get; set; }

        public Contractor FromContractor { get; set; }

        public long ForContractorId { get; set; }

        public Contractor ForContractor { get; set; }

        public DateTime InvoiceDate { get; set; }

        public DateTime DueDate { get; set; }

        public DateTime SaleDate { get; set; }

        public decimal NetAmount { get; set; }

        public string NetCurrency { get; set; }

        public decimal GrossAmount { get; set; }

        public string GrossCurrency { get; set; }

        public decimal VatPercent { get; set; }

        public int NumberOfUnits { get; set; }

        public string UnitName { get; set; }

        public long PkwiuId { get; set; }

        public Pkwiu Pkwiu { get; set; }
    }
}
