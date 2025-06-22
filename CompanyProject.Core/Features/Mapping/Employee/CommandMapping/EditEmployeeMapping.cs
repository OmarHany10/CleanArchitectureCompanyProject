using CompanyProject.Core.Features.Employees.Commands.Models;

namespace CompanyProject.Core.Features.Mapping.Employee
{
    public partial class EmployeeProfile
    {
        public void EditEmployeeMapping()
        {
            CreateMap<EditEmployeeComand, Data.Models.Employee>();
        }
    }
}
