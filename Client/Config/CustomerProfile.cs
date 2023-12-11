using AutoMapper;
using Client.Helpers;
using Client.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.Config
{
    public class CustomerProfile : Profile
    {
        public CustomerProfile()
        {
            CreateMap<ApiRequestResult<DatSoModel>, ApiRequestResult>()
                .ForMember(dest => dest.Result, opt => opt.Ignore());
        }
    }
}
