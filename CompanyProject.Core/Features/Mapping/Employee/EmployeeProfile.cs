using AutoMapper;

namespace CompanyProject.Core.Features.Mapping.Employee
{
    public partial class EmployeeProfile : Profile
    {
        public EmployeeProfile()
        {
            GetEmployeeListMapping();
            GetEmployeeByIdMapping();
            AddEmployeeMapping();
        }
    }
}
