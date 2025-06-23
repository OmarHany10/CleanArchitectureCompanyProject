using CompanyProject.Core.Features.Employees.Queries.DTOs;
using CompanyProject.Core.Wrabbers;
using CompanyProject.Data.Enums;
using MediatR;

namespace CompanyProject.Core.Features.Employees.Queries.Models
{
    public class GetEmployeePaginatiedListQuery : IRequest<PaginatedResult<GetEmployeePaginatedListDTO>>
    {
        public int PageSize { get; set; }
        public int PageNumber { get; set; }
        public string? Search { get; set; }
        public EmployeeOrderingEnum Orders { get; set; }
    }
}
