using BFinances.Server.Common.Domain.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace BFinances.Server.Expenses.Domain.Model
{
    public class Expense : Entity
    {
        public string ExpenseeNo { get; set; }

        public long FromContractorId { get; set; }

        public Contractor FromContractor { get; set; }

        public long ForContractorId { get; set; }

        public Contractor ForContractor { get; set; }

        public DateTime ExpenseDate { get; set; }

        public DateTime DueDate { get; set; }

        public DateTime SaleDate { get; set; }

        public decimal VatSum { get; set; }

        public decimal NetSum { get; set; }

        public decimal GrossSum { get; set; }
    }
}