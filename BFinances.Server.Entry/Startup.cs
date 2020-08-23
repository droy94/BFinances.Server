using Autofac;
using Autofac.Extensions.DependencyInjection;
using BFinances.Server.Common.Infrastructure.Autofac;
using BFinances.Server.Common.Infrastructure.Repository;
using BFinances.Server.Dashboard.Application.Controllers;
using BFinances.Server.Dashboard.Infrastructure.Autofac;
using BFinances.Server.Expenses.Application.Controllers;
using BFinances.Server.Expenses.Infrastructure.Autofac;
using BFinances.Server.Expenses.Infrastructure.Repository;
using BFinances.Server.Invoices.Application.Controllers;
using BFinances.Server.Invoices.Infrastructure.Autofac;
using BFinances.Server.Invoices.Infrastructure.Repository;
using DinkToPdf;
using DinkToPdf.Contracts;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.ApplicationParts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace BFinances.Server.Entry
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public ILifetimeScope AutofacContainer { get; private set; }

        public void ConfigureContainer(ContainerBuilder builder)
        {
            builder.RegisterModule(new CommonModule());
            builder.RegisterModule(new InvoicesModule());
            builder.RegisterModule(new ExpensesModule());
            builder.RegisterModule(new DashboardModule());
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddHttpClient();

            services.AddDbContext<InvoicesDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("BFinances")));

            services.AddDbContext<ExpensesDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("BFinances")));

            services.AddDbContext<CommonDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("BFinances")));

            var invoicesAssembly = typeof(InvoicesController).Assembly;
            var expensesAssembly = typeof(ExpensesController).Assembly;
            var dashboardAssembly = typeof(DashboardController).Assembly;

            services.AddSingleton(typeof(IConverter), new SynchronizedConverter(new PdfTools()));

            services.AddControllers()
                .PartManager.ApplicationParts.Add(new AssemblyPart(invoicesAssembly));

            services.AddControllers()
                .PartManager.ApplicationParts.Add(new AssemblyPart(expensesAssembly));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            AutofacContainer = app.ApplicationServices.GetAutofacRoot();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseCors(builder => builder.WithOrigins("http://localhost:4200")
                .AllowAnyMethod()
                .AllowAnyHeader());

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}