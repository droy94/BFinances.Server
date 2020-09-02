using BFinances.Server.Invoices.Contract.Providers;
using BFinances.Server.Invoices.Contract.Response;
using BFinances.Server.Invoices.Contract.Service;
using BFinances.Server.Invoices.Domain.Service;
using DinkToPdf;
using DinkToPdf.Contracts;
using Moq;
using System.Threading.Tasks;
using Xunit;

namespace BFinances.Server.Invoices.Domain.Unit.Tests.Service
{
    public class InvoicePdfServiceTests
    {
        [Fact]
        public async Task Generate_OnProperParameter_CallsConcreteMethods()
        {
            // Arrange
            var templateGeneratorMock = new Mock<IInvoiceTemplateGenerator>();
            var invoicesProviderMock = new Mock<IInvoicesProvider>();
            var pdfConverterMock = new Mock<IConverter>();

            var invoicePdfService =
                new InvoicePdfService(templateGeneratorMock.Object, invoicesProviderMock.Object, pdfConverterMock.Object);

            // Act
            await invoicePdfService.Generate(1);

            // Assert
            templateGeneratorMock.Verify(mock => mock.GetContent(It.IsAny<InvoiceResponse>()), Times.Once);
            invoicesProviderMock.Verify(mock => mock.GetInvoice(It.IsAny<long>()), Times.Once);
            pdfConverterMock.Verify(mock => mock.Convert(It.IsAny<HtmlToPdfDocument>()), Times.Once);
        }
    }
}