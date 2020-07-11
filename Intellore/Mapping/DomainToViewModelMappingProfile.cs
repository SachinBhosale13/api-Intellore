using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;

namespace Intellore.Mapping
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public override string ProfileName
        {
            get { return "DomainToViewModelMappings"; }
        }
        public DomainToViewModelMappingProfile()
        {
            //CreateMap<PermanentFormPersonalDetail, PermanentFormPersonalDetailViewModel>()
            //                 .ForMember(c => c.stringBirthDate, opts => opts.Ignore())
            //                .ForMember(c => c.stringDemandDraftDate, opts => opts.Ignore());
        }
    }
}