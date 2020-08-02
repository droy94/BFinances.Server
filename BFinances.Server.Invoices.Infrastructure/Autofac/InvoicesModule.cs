using Autofac;
using AutoMapper.Contrib.Autofac.DependencyInjection;
using BFinances.Server.Invoices.Contract.Providers;
using BFinances.Server.Invoices.Contract.Service;
using BFinances.Server.Invoices.Domain.Service;
using BFinances.Server.Invoices.Infrastructure.AutoMapper;
using BFinances.Server.Invoices.Infrastructure.Providers;
using BFinances.Server.Invoices.Infrastructure.Repository;
using DinkToPdf;
using DinkToPdf.Contracts;

namespace BFinances.Server.Invoices.Infrastructure.Autofac
{
    public class InvoicesModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<InvoicesProvider>()
                .As<IInvoicesProvider>()
                .InstancePerLifetimeScope();

            builder.RegisterType<PkwiuProvider>()
                .As<IPkwiuProvider>()
                .InstancePerLifetimeScope();

            builder.RegisterType<InvoiceTemplateGenerator>()
                .As<IInvoiceTemplateGenerator>();
            builder.RegisterType<InvoicePdfService>()
                .As<IInvoicePdfService>();

            builder.AddAutoMapper(typeof(InvoicesProfile).Assembly);
        }
    }
}