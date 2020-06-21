using Autofac;
using AutoMapper.Contrib.Autofac.DependencyInjection;
using BFinances.Server.Invoices.Contract.Providers;
using BFinances.Server.Invoices.Infrastructure.AutoMapper;
using BFinances.Server.Invoices.Infrastructure.Providers;
using BFinances.Server.Invoices.Infrastructure.Repository;

namespace BFinances.Server.Invoices.Infrastructure.Autofac
{
    public class InvoicesModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            //builder.RegisterType<InvoicesDbContext>()
            //    .As<IInvoicesDbContext>()
            //    .InstancePerLifetimeScope();

            // TODO: Zastanowić się czy tu pasuje SingleInstance. Jak jest w pracy?
            builder.RegisterType<InvoicesDbContext>()
                .AsSelf();

            builder.RegisterType<InvoicesProvider>()
                .As<IInvoicesProvider>()
                .InstancePerLifetimeScope();

            builder.RegisterType<ContractorProvider>()
                .As<IContractorProvider>()
                .InstancePerLifetimeScope();

            builder.RegisterType<PkwiuProvider>()
                .As<IPkwiuProvider>()
                .InstancePerLifetimeScope();

            builder.AddAutoMapper(typeof(InvoicesProfile).Assembly);
        }
    }
}
