using Autofac;

namespace BFinances.Server.Invoices.Infrastructure.Autofac
{
    public class InvoicesModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            //builder.RegisterType<FlightsService>()
            //    .As<IFlightsService>()
            //    .InstancePerLifetimeScope();
        }
    }
}
