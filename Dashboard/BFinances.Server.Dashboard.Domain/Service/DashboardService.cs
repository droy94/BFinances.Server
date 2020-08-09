using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BFinances.Server.Dashboard.Contract.Response;
using BFinances.Server.Dashboard.Contract.Service;
using BFinances.Server.Expenses.Contract.Providers;
using BFinances.Server.Invoices.Contract.Providers;

namespace BFinances.Server.Dashboard.Domain.Service
{
    public class DashboardService : IDashboardService
    {
        private readonly IExpensesProvider _expensesProvider;
        private readonly IInvoicesProvider _invoicesProvider;
        private decimal PitPercent => 18m;

        // TODO: Add DateTime filter
        public DashboardService(IExpensesProvider expensesProvider, IInvoicesProvider invoicesProvider)
        {
            _expensesProvider = expensesProvider;
            _invoicesProvider = invoicesProvider;
        }

        public async Task<DashboardResponse> Get()
        {
            var expenses = await _expensesProvider.GetAll();
            var invoices = await _invoicesProvider.GetAll();

            var grossIncome = invoices.Sum(x => x.NetSum);
            var incomeCosts = expenses.Sum(x => x.NetAmount);
            var pit = grossIncome * PitPercent / 100;
            var payablePit = (grossIncome - incomeCosts) * PitPercent;
            var vat = invoices.Sum(x => x.VatSum);
            //var payableVat = vat -

            //var netIncome = grossIncome - (grossIncome - incomeCosts) * Pit / 100;
        }
    }
}