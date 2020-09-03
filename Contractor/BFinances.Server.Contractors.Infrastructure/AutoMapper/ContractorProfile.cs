using AutoMapper;
using BFinances.Server.Contractors.Contract.Request;
using BFinances.Server.Contractors.Contract.Response;
using BFinances.Server.Contractors.Domain.Model;

namespace BFinances.Server.Contractors.Infrastructure.AutoMapper
{
    public class ContractorProfile : Profile
    {
        public ContractorProfile()
        {
            CreateMap<Contractor, ContractorResponse>();

            CreateMap<ContractorRequest, Contractor>();
        }
    }
}