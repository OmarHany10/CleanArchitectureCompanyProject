using CompanyProject.Core.Features.Employees.Queries.DTOs;

namespace CompanyProject.Core.Features.Mapping.Employee
{
    public partial class EmployeeProfile
    {
        public void GetEmployeeByIdMapping()
        {
            CreateMap<Data.Models.Employee, GetEmployeeByIdDTO>().
                ForMember(dest => dest.DepartmentName, options => options.MapFrom(src => src.Department.Name));
        }
    }
}
