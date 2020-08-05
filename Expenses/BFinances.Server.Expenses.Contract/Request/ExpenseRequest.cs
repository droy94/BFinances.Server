using System;
using System.Collections.Generic;
using System.Text;
using BFinances.Server.Common.Contract.Request;

namespace BFinances.Server.Expenses.Contract.Request
{
    public class ExpenseRequest
    {
        public long Id { get; set; }

        public string Name { get; set; }

        public string ExpenseNo { get; set; }

        public long FromContractorId { get; set; }

        public ContractorRequest FromContractor { get; set; }

        public long ForContractorId { get; set; }

        public ContractorRequest ForContractor { get; set; }

        public DateTime ExpenseDate { get; set; }

        public DateTime DueDate { get; set; }

        public decimal VatAmount => NetAmount * VatPercent / 100;

        public decimal NetAmount { get; set; }

        public decimal GrossAmount => VatAmount + NetAmount;

        public decimal VatPercent { get; set; }
    }
}