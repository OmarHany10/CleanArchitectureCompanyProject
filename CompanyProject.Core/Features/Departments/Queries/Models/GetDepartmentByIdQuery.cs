using CompanyProject.Core.Features.Departments.Queries.DTOs;
using CompanyProject.Core.Responses;
using MediatR;

namespace CompanyProject.Core.Features.Departments.Queries.Models
{
    public class GetDepartmentByIdQuery : IRequest<Response<GetDepartmentByIdDTO>>
    {
        public GetDepartmentByIdQuery(int id)
        {
            Id = id;
        }
        public int Id { get; set; }
    }
}
