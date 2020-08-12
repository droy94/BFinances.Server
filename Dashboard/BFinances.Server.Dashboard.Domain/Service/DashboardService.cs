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
            var today = DateTime.Today;

            var expenses = await _expensesProvider.Get(today.Month, today.Year);
            var invoices = await _invoicesProvider.Get(today.Month, today.Year);

            // Przychód netto bez odliczeń
            var grossIncome = invoices.Sum(x => x.NetSum);

            // Koszt uzyskania przychodu
            var incomeCosts = expenses.Sum(x => x.NetAmount);

            // Pit do zapłaty
            var payablePit = (grossIncome - incomeCosts) * PitPercent;

            var vat = invoices.Sum(x => x.VatSum);

            // Vat do zapłaty
            var payableVat = vat - expenses.Sum(x => x.VatAmount);

            var dashboardResponse = new DashboardResponse
            {
                GrossIncome = grossIncome,
                PayablePit = payablePit > 0 ? payablePit : 0,
                PayableVat = payableVat > 0 ? payableVat : 0
            };

            return dashboardResponse;
        }
    }
}