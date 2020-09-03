using Autofac;
using AutoMapper.Contrib.Autofac.DependencyInjection;
using BFinances.Server.Contractors.Contract.Providers;
using BFinances.Server.Contractors.Infrastructure.AutoMapper;
using BFinances.Server.Contractors.Infrastructure.Providers;

namespace BFinances.Server.Contractors.Infrastructure.Autofac
{
    public class ContractorModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<ContractorProvider>()
                .As<IContractorProvider>()
                .InstancePerLifetimeScope();

            builder.AddAutoMapper(typeof(ContractorProfile).Assembly);
        }
    }
}