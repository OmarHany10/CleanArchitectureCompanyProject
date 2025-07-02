using CompanyProject.Core.Features.Employees.Queries.DTOs;
using CompanyProject.Core.Responses;
using MediatR;

namespace CompanyProject.Core.Features.Employees.Queries.Models
{
    public class GetEmployeeByIdQuery : IRequest<Response<GetEmployeeByIdDTO>>
    {
        public GetEmployeeByIdQuery(int id)
        {
            Id = id;
        }
        public int Id { get; set; }
    }
}
