using System;
using System.Collections.Generic;
using System.Text;
using Autofac;
using BFinances.Server.Expenses.Infrastructure.Repository;

namespace BFinances.Server.Expenses.Infrastructure.Autofac
{
    public class ExpensesModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<ExpenseDbContext>()
                .AsSelf();

            //builder.AddAutoMapper(typeof(InvoicesProfile).Assembly);
        }
    }
}