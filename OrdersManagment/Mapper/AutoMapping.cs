using AutoMapper;
using OrdersManagment.Models.Response;
using OrdersManagment.Models.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMS.Configurations.Mapper
{
    public class AutoMapping : Profile
    {
        public AutoMapping()
        {
            CreateMap<Users, LoginResponse>();
            CreateMap<Users, UsersResponse>();
            CreateMap<Tasks, TasksResponse>()
           .ForMember(dest => dest.statusName, opt => opt.MapFrom(src => src.status.name))
           .ForMember(dest => dest.userName, opt => opt.MapFrom(src => src.user.userName));
        }
    }
}
