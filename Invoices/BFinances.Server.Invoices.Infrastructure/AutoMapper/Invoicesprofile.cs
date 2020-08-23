using AutoMapper;
using BFinances.Server.Invoices.Contract.Request;
using BFinances.Server.Invoices.Contract.Response;
using BFinances.Server.Invoices.Domain.Model;
using System;

namespace BFinances.Server.Invoices.Infrastructure.AutoMapper
{
    public class InvoicesProfile : Profile
    {
        public InvoicesProfile()
        {
            CreateMap<Invoice, InvoiceResponse>();
            CreateMap<Pkwiu, PkwiuResponse>();
            CreateMap<InvoiceItem, InvoiceItemResponse>();
            CreateMap<PkwiuRequest, Pkwiu>();

            CreateMap<InvoiceRequest, Invoice>()
                .ForMember(x => x.Id,
                    opts => opts.Ignore())
                .ForMember(x => x.InvoiceNo,
                    opts => opts.Ignore())
                .ForMember(x => x.FromContractorId,
                    opts => opts.MapFrom(y => 1))
                .ForMember(x => x.ForContractorId,
                    opts => opts.MapFrom(y => y.ForContractor.Id))
                .ForMember(x => x.ForContractor,
                    opts => opts.Ignore())
                .ForMember(x => x.FromContractor,
                    opts => opts.Ignore());

            CreateMap<InvoiceItemRequest, InvoiceItem>()
                .ForMember(x => x.InvoiceId,
                    opts => opts.Ignore())
                .ForMember(x => x.PkwiuId,
                    opts => opts.MapFrom(y => y.Pkwiu.Id))
                .ForMember(x => x.Pkwiu,
                    opts => opts.Ignore());
        }

        private string GetNumber(DateTime invoiceDate)
        {
            return $"{invoiceDate.Month}/{invoiceDate.Year}";
        }
    }
}