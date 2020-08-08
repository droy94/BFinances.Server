using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using BFinances.Server.Expenses.Contract.Request;
using BFinances.Server.Expenses.Contract.Response;

namespace BFinances.Server.Expenses.Contract.Providers
{
    public interface IExpensesProvider
    {
        Task<List<ExpenseResponse>> GetAll();

        Task CreateExpense(ExpenseRequest expenseRequest);

        Task EditExpense(ExpenseRequest expenseRequest, long id);

        Task<ExpenseResponse> Get(long id);

        Task DeleteExpense(long id);
    }
}