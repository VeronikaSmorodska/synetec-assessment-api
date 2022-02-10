using AutoMapper;
using SynetecAssessmentApi.Dtos;
namespace SynetecAssessmentApi.Domain.Mapper
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<Employee, EmployeeDto>()
                .ForMember(u => u.Fullname, o => o.MapFrom(y => y.Fullname))
                .ForMember(u => u.JobTitle, o => o.MapFrom(y => y.JobTitle))
                .ForMember(u => u.Salary, o => o.MapFrom(y => y.Salary))
                .ReverseMap();
            CreateMap<Department, DepartmentDto>()
                .ForMember(u => u.Title, o => o.MapFrom(y => y.Title))
                .ForMember(u => u.Description, o => o.MapFrom(y => y.Description))
                .ReverseMap();

        }
    }
}
