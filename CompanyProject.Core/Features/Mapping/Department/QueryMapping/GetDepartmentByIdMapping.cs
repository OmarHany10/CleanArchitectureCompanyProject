
using CompanyProject.Core.Features.Departments.Queries.DTOs;
using CompanyProject.Data.Commands;

namespace CompanyProject.Core.Features.Mapping.Department
{
    public partial class DeparmtentProfile
    {
        public void GetDepartmentByIdMapping()
        {
            CreateMap<Data.Models.Employee, ItemDTO>();
            CreateMap<Data.Models.ProjectLeader, ItemDTO>();
            CreateMap<Data.Models.DepartmentProject, ItemDTO>()
                .ForMember(dst => dst.Name, opt => opt.MapFrom(src => src.Project.ProjectName))
                .ForMember(dst => dst.Id, opt => opt.MapFrom(src => src.ProjectId));

            CreateMap<Data.Models.Department, GetDepartmentByIdDTO>()
                .ForMember(dst => dst.Name, opt => opt.MapFrom(src => GeneralLocalizable.Localize(src.NameAr, src.NameEn)))
                .ForMember(dst => dst.MangerName, opt => opt.MapFrom(src => src.LeaderManger.Name))
                .ForMember(dst => dst.Employees, opt => opt.MapFrom(src => src.Employees))
                .ForMember(dst => dst.ProjectLeaders, opt => opt.MapFrom(src => src.ProjectLeaders))
                .ForMember(dst => dst.Projects, opt => opt.MapFrom(src => src.DepartmentProjects));
        }
    }
}
