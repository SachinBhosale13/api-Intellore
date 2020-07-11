using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;

namespace Intellore.Mapping
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {                //CreateMap<PermanentFormPersonalDetail, PermanentFormPersonalDetailViewModel>()
            //      .ForMember(c => c., opts => opts.Ignore())
            //     .ForMember(c => c.VaTimeZones, opts => opts.Ignore())

            //CreateMap<PermanentFormPersonalDetailViewModel, PermanentFormPersonalDetail>()
            //      .ForMember(c => c.DateofBirth, opts => opts.Ignore())
            //     .ForMember(c => c.DemandDraftDate, opts => opts.Ignore());
        }
    }
}