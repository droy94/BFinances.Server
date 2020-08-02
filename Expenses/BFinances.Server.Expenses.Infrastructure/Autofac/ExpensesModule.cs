using System;
using System.Collections.Generic;
using System.Text;
using Autofac;
using AutoMapper.Contrib.Autofac.DependencyInjection;
using BFinances.Server.Expenses.Infrastructure.AutoMapper;
using BFinances.Server.Expenses.Infrastructure.Repository;

namespace BFinances.Server.Expenses.Infrastructure.Autofac
{
    public class ExpensesModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.AddAutoMapper(typeof(ExpensesProfile).Assembly);
        }
    }
}