using AutoMapper;
using DataAccess.Models;
using Microsoft.Extensions.Logging;
using UserService.Models.DTOModels;
using UserService.Models.ResponseModels;

namespace UserService.Helpers
{
    public class AutoMapper : Profile
    {
        public AutoMapper()
        {
            CreateMap<EmployeeDTO, EmployeeEntity>()
                 .ForMember(x => x.FirstName, opt => opt.MapFrom(x => x.FirstName))
                 .ForMember(x => x.LastName, opt => opt.MapFrom(x => x.LastName))
                 .ForMember(x => x.Age, opt => opt.MapFrom(x => x.Age))
                 .ForMember(x => x.Gender, opt => opt.MapFrom(x => x.Gender.ToString()));

            CreateMap<EmployeeEntity, EmployeeDTO>()
                 .ForMember(x => x.FirstName, opt => opt.MapFrom(x => x.FirstName))
                 .ForMember(x => x.LastName, opt => opt.MapFrom(x => x.LastName))
                 .ForMember(x => x.Age, opt => opt.MapFrom(x => x.Age))
                 .ForMember(x => x.Gender, opt => opt.MapFrom(x => x.Gender.ToString()));

            CreateMap<EmployeeDTO, EmployeeResponseModel>();
            CreateMap<EmployeeResponseModel, EmployeeDTO>();
        }
        
    }
}
