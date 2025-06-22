using CompanyProject.Core.Responses;
using MediatR;

namespace CompanyProject.Core.Features.Employees.Commands.Models
{
    public class EditEmployeeComand : IRequest<Response<string>>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public int DepartmentId { get; set; }
    }
}
