using System;
using System.Collections.Generic;
using System.Text;
using Autofac;
using BFinances.Server.Dashboard.Contract.Service;
using BFinances.Server.Dashboard.Domain.Service;

namespace BFinances.Server.Dashboard.Infrastructure.Autofac
{
    public class DashboardModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<DashboardService>()
                .As<IDashboardService>()
                .InstancePerLifetimeScope();
        }
    }
}