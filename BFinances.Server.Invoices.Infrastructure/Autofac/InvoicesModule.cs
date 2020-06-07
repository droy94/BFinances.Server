using Autofac;
using BFinances.Server.Invoices.Contract.Flights;

namespace BFinances.Server.Invoices.Infrastructure.Autofac
{
    public class InvoicesModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<FlightsService>()
                .As<IFlightsService>()
                .InstancePerLifetimeScope();
        }
    }
}
