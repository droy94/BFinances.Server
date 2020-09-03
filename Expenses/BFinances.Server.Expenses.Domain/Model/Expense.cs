using BFinances.Server.Common.Domain.Model;
using BFinances.Server.Contractors.Domain.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace BFinances.Server.Expenses.Domain.Model
{
    public class Expense : Entity
    {
        public string Name { get; set; }

        public string ExpenseNo { get; set; }

        public long FromContractorId { get; set; }

        public Contractor FromContractor { get; set; }

        public long ForContractorId { get; set; }

        public Contractor ForContractor { get; set; }

        public DateTime ExpenseDate { get; set; }

        public DateTime DueDate { get; set; }

        public decimal VatAmount { get; set; }

        public decimal NetAmount { get; set; }

        public decimal GrossAmount { get; set; }

        public decimal VatPercent { get; set; }
    }
}