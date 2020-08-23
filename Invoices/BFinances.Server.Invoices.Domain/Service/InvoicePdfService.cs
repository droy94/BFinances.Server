using BFinances.Server.Invoices.Contract.Providers;
using BFinances.Server.Invoices.Contract.Service;
using DinkToPdf;
using DinkToPdf.Contracts;
using System.Threading.Tasks;

namespace BFinances.Server.Invoices.Domain.Service
{
    public class InvoicePdfService : IInvoicePdfService
    {
        private readonly IInvoiceTemplateGenerator _templateGenerator;
        private readonly IInvoicesProvider _invoicesProvider;
        private readonly IConverter _pdfConverter;

        public InvoicePdfService(
            IInvoiceTemplateGenerator templateGenerator,
            IInvoicesProvider invoicesProvider,
            IConverter pdfConverter)
        {
            _templateGenerator = templateGenerator;
            _invoicesProvider = invoicesProvider;
            _pdfConverter = pdfConverter;
        }

        public async Task<byte[]> Generate(long invoiceId)
        {
            var invoice = await _invoicesProvider.GetInvoices(invoiceId);

            var globalSettings = new GlobalSettings
            {
                ColorMode = ColorMode.Color,
                Orientation = Orientation.Portrait,
                PaperSize = PaperKind.A4,
                Margins = new MarginSettings { Top = 10 },
                DocumentTitle = $"faktura"
            };

            var objectSettings = new ObjectSettings
            {
                PagesCount = true,
                HtmlContent = _templateGenerator.GetContent(invoice),
                WebSettings =
                {
                    DefaultEncoding = "utf-8",
                    UserStyleSheet = "C:\\ThesisRepo\\BFinances.Server\\Invoices\\BFinances.Server.Invoices.Domain\\Service\\Assets\\style.css"
                },
                FooterSettings = { FontName = "Arial", FontSize = 9, Line = true, Center = "Strona [page] z [toPage]" }
            };

            var pdf = new HtmlToPdfDocument
            {
                GlobalSettings = globalSettings,
                Objects = { objectSettings }
            };

            return _pdfConverter.Convert(pdf);
        }
    }
}