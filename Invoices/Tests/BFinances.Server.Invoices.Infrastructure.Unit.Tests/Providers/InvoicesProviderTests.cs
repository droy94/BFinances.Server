using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using BFinances.Server.Common.Domain.Model;
using BFinances.Server.Invoices.Domain.Model;
using BFinances.Server.Invoices.Infrastructure.Repository;
using Microsoft.EntityFrameworkCore;

namespace BFinances.Server.Invoices.Infrastructure.Unit.Tests.Providers
{
    public class InvoicesProviderTests
    {
        private DbContextOptions<InvoicesDbContext> _options;

        public InvoicesProviderTests()
        {
            _options = new DbContextOptionsBuilder<InvoicesDbContext>()
                .UseInMemoryDatabase(databaseName: "BFinances")
                .Options;
        }

        //public async Task Test()
        //{
        //    var contractor = new Contractor
        //    {
        //        Name = "DANIEL ROJEK",
        //        Nip = "1234567890"
        //    };

        //    var pkwiu = new Pkwiu
        //    {
        //        Name = "Usługi IT",
        //        Code = "6.2.1"
        //    };

        //    var invoiceItems = new InvoiceItem
        //    {
        //        Pkwiu = pkwiu,
        //        GrossSum = 1230,
        //    }

        //    using (var context = new InvoicesDbContext(_options))
        //    {
        //        context.Invoices
        //        context.SaveChanges();
        //    }

        //    using (var context = new MovieDbContext(_options))
        //    {
        //        MovieRepository movieRepository = new MovieRepository(context);
        //        List<Movies> movies == movieRepository.GetAll()

        //        Assert.Equal(3, movies.Count);
        //    }
        //}
    }
}