using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using BFinances.Server.Common.Contract.Request;
using BFinances.Server.Common.Contract.Response;
using BFinances.Server.Common.Domain.Model;

namespace BFinances.Server.Common.Infrastructure.AutoMapper
{
    public class CommonProfile : Profile
    {
        public CommonProfile()
        {
            CreateMap<Contractor, ContractorResponse>();

            CreateMap<ContractorRequest, Contractor>();
        }
    }
}