using CompanyProject.Core.Features.Employees.Queries.DTOs;
using CompanyProject.Data.Commands;

namespace CompanyProject.Core.Features.Mapping.Employee
{
    public partial class EmployeeProfile
    {
        public void GetEmployeeByIdMapping()
        {
            CreateMap<Data.Models.Employee, GetEmployeeByIdDTO>().
                ForMember(dest => dest.DepartmentName, options => options.MapFrom(src => GeneralLocalizable.Localize(src.Department.NameAr, src.Department.NameEn)));
        }
    }
}
