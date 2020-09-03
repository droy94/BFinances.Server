using System;
using System.Collections.Generic;
using System.Text;
using BFinances.Server.Contractors.Contract.Response;

namespace BFinances.Server.Expenses.Contract.Response
{
    public class ExpenseResponse
    {
        public long Id { get; set; }

        public string Name { get; set; }

        public string ExpenseNo { get; set; }

        public long FromContractorId { get; set; }

        public ContractorResponse FromContractor { get; set; }

        public long ForContractorId { get; set; }

        public ContractorResponse ForContractor { get; set; }

        public DateTime ExpenseDate { get; set; }

        public DateTime DueDate { get; set; }

        public decimal VatAmount { get; set; }

        public decimal NetAmount { get; set; }

        public decimal GrossAmount { get; set; }

        public decimal VatPercent { get; set; }
    }
}