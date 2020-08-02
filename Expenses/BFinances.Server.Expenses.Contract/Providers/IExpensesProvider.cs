using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using BFinances.Server.Expenses.Contract.Response;

namespace BFinances.Server.Expenses.Contract.Providers
{
    public interface IExpensesProvider
    {
        Task<List<ExpenseResponse>> GetAll();
    }
}