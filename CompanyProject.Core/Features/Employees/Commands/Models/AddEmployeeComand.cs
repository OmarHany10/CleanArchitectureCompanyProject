using CompanyProject.Core.Responses;
using MediatR;

namespace CompanyProject.Core.Features.Employees.Commands.Models
{
    public class AddEmployeeComand : IRequest<Response<string>>
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public int DepartmentId { get; set; }
    }
}
