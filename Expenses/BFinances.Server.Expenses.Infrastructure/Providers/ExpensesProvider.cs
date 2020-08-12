using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using BFinances.Server.Expenses.Contract.Providers;
using BFinances.Server.Expenses.Contract.Request;
using BFinances.Server.Expenses.Contract.Response;
using BFinances.Server.Expenses.Domain.Model;
using BFinances.Server.Expenses.Infrastructure.Repository;
using Microsoft.EntityFrameworkCore;

namespace BFinances.Server.Expenses.Infrastructure.Providers
{
    public class ExpensesProvider : IExpensesProvider
    {
        private readonly ExpensesDbContext _dbContext;
        private readonly IMapper _mapper;

        public ExpensesProvider(ExpensesDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<List<ExpenseResponse>> Get(int month, int year)
        {
            var expenses = await _dbContext.Set<Expense>()
                .Where(x => x.ExpenseDate.Month == month && x.ExpenseDate.Year == year)
                .Include(x => x.FromContractor)
                .Include(x => x.ForContractor)
                .OrderByDescending(x => x.ExpenseDate)
                .ToListAsync();

            var response = _mapper.Map<List<ExpenseResponse>>(expenses);

            return response;
        }

        public async Task CreateExpense(ExpenseRequest expenseRequest)
        {
            var expense = _mapper.Map<Expense>(expenseRequest);

            await _dbContext.Set<Expense>().AddAsync(expense);

            await _dbContext.SaveChangesAsync();
        }

        public async Task EditExpense(ExpenseRequest expenseRequest, long id)
        {
            var expenseToEdit = await _dbContext.Set<Expense>()
                .Where(x => x.Id == id)
                .FirstOrDefaultAsync();

            _mapper.Map(expenseRequest, expenseToEdit);

            await _dbContext.SaveChangesAsync();
        }

        public async Task<ExpenseResponse> Get(long id)
        {
            var expense = await _dbContext.Set<Expense>()
                .Include(x => x.FromContractor)
                .Include(x => x.ForContractor)
                .Where(x => x.Id == id)
                .FirstOrDefaultAsync();

            var response = _mapper.Map<ExpenseResponse>(expense);

            return response;
        }

        public async Task DeleteExpense(long id)
        {
            var expense = await _dbContext.Set<Expense>()
                .Where(x => x.Id == id)
                .FirstOrDefaultAsync();

            _dbContext.Set<Expense>().Remove(expense);

            await _dbContext.SaveChangesAsync();
        }
    }
}