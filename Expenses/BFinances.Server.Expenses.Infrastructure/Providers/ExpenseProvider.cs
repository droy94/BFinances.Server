using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using BFinances.Server.Expenses.Contract.Response;
using BFinances.Server.Expenses.Domain.Model;
using BFinances.Server.Expenses.Infrastructure.Repository;
using Microsoft.EntityFrameworkCore;

namespace BFinances.Server.Expenses.Infrastructure.Providers
{
    public class ExpenseProvider
    {
        private readonly ExpensesDbContext _dbContext;
        private readonly IMapper _mapper;

        public ExpenseProvider(ExpensesDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<List<ExpenseResponse>> GetAll()
        {
            var expenses = await _dbContext.Set<Expense>()
                .Include(x => x.FromContractor)
                .Include(x => x.ForContractor)
                .OrderByDescending(x => x.ExpenseDate)
                .ToListAsync();

            var response = _mapper.Map<List<ExpenseResponse>>(expenses);

            return response;
        }
    }
}