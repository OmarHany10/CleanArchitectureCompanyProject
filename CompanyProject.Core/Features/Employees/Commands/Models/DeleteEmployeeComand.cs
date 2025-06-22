using CompanyProject.Core.Responses;
using MediatR;

namespace CompanyProject.Core.Features.Employees.Commands.Models
{
    public class DeleteEmployeeComand : IRequest<Response<string>>
    {
        public DeleteEmployeeComand(int Id)
        {
            this.Id = Id;
        }
        public int Id { get; set; }
    }
}
