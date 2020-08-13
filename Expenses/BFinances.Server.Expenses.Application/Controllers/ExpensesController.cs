using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using BFinances.Server.Expenses.Contract.Providers;
using BFinances.Server.Expenses.Contract.Request;
using BFinances.Server.Expenses.Contract.Response;

namespace BFinances.Server.Expenses.Application.Controllers
{
    [Route("api/[controller]")]
    public class ExpensesController : ControllerBase
    {
        private readonly IExpensesProvider _expensesProvider;

        public ExpensesController(IExpensesProvider expensesProvider)
        {
            _expensesProvider = expensesProvider;
        }

        [HttpGet]
        public Task<List<ExpenseResponse>> GetExpenses([FromQuery] int month, [FromQuery] int year)
        {
            return _expensesProvider.GetExpenses(month, year);
        }

        [HttpPost]
        public Task CreateExpense([FromBody]ExpenseRequest expense)
        {
            return _expensesProvider.CreateExpense(expense);
        }

        [HttpPut("{id}")]
        public Task EditExpense([FromBody]ExpenseRequest expense, long id)
        {
            return _expensesProvider.EditExpense(expense, id);
        }

        [HttpGet("{id}")]
        public Task<ExpenseResponse> GetExpense(long id)
        {
            return _expensesProvider.GetExpenses(id);
        }

        [HttpDelete("{id}")]
        public Task DeleteExpense(long id)
        {
            return _expensesProvider.DeleteExpense(id);
        }
    }
}