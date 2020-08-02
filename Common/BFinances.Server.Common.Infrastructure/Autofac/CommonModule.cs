using System;
using System.Collections.Generic;
using System.Text;
using Autofac;
using AutoMapper.Contrib.Autofac.DependencyInjection;
using BFinances.Server.Common.Contract.Providers;
using BFinances.Server.Common.Infrastructure.AutoMapper;
using BFinances.Server.Common.Infrastructure.Providers;
using BFinances.Server.Common.Infrastructure.Repository;

namespace BFinances.Server.Common.Infrastructure.Autofac
{
    public class CommonModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<ContractorProvider>()
                .As<IContractorProvider>()
                .InstancePerLifetimeScope();

            builder.AddAutoMapper(typeof(CommonProfile).Assembly);
        }
    }
}