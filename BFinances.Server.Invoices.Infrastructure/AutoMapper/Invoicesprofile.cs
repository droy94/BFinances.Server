using AutoMapper;
using BFinances.Server.Invoices.Contract.Response;
using BFinances.Server.Invoices.Domain.Model;

namespace BFinances.Server.Invoices.Infrastructure.AutoMapper
{
    public class InvoicesProfile : Profile
    {
        public InvoicesProfile()
        {
            CreateMap<Invoice, InvoiceResponse>()
                .ForMember(x => x.FromContractor,
                    opts => opts.MapFrom(y => y.FromContractor.Name))
                .ForMember(x => x.ForContractor,
                    opts => opts.MapFrom(y => y.ForContractor.Name))
                .ForMember(x => x.Pkwiu,
                    opts => opts.MapFrom(y => y.Pkwiu.Code));

            CreateMap<Contractor, ContractorResponse>();

            CreateMap<Pkwiu, PkwiuResponse>();
        }
    }
}
