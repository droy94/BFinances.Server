using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using BFinances.Server.Expenses.Contract.Request;
using BFinances.Server.Expenses.Contract.Response;
using BFinances.Server.Expenses.Domain.Model;

namespace BFinances.Server.Expenses.Infrastructure.AutoMapper
{
    public class ExpensesProfile : Profile
    {
        public ExpensesProfile()
        {
            CreateMap<Expense, ExpenseResponse>();

            // TODO: number będzie numerem fv w miesiącu, a fromContractor będzie z identity
            CreateMap<ExpenseRequest, Expense>()
                .ForMember(x => x.Id,
                    opts => opts.Ignore())
                .ForMember(x => x.ExpenseNo,
                    opts => opts.MapFrom(y => GetNumber(y.ExpenseDate)))
                .ForMember(x => x.FromContractorId,
                    opts => opts.MapFrom(y => y.FromContractor.Id))
                .ForMember(x => x.ForContractorId,
                    opts => opts.MapFrom(y => 1))
                .ForMember(x => x.ForContractor,
                    opts => opts.Ignore())
                .ForMember(x => x.FromContractor,
                    opts => opts.Ignore());
        }

        private string GetNumber(DateTime invoiceDate)
        {
            return $"{invoiceDate.Month}/{invoiceDate.Year}";
        }
    }
}