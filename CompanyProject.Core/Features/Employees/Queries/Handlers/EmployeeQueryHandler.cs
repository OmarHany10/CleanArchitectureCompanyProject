using AutoMapper;
using CompanyProject.Core.Features.Employees.Queries.DTOs;
using CompanyProject.Core.Features.Employees.Queries.Models;
using CompanyProject.Core.Responses;
using CompanyProject.Core.Wrabbers;
using CompanyProject.Data.Models;
using CompanyProject.Service.Interfaces;
using MediatR;
using System.Linq.Expressions;

namespace CompanyProject.Core.Features.Employees.Queries.Handlers
{
    public class EmployeeQueryHandler : ResponseHandler,
        IRequestHandler<GetEmployeeListQuery, Response<List<GetEmployeeListDTO>>>,
        IRequestHandler<GetEmployeeByIdQuery, Response<GetEmployeeByIdDTO>>,
        IRequestHandler<GetEmployeePaginatiedListQuery, PaginatedResult<GetEmployeePaginatedListDTO>>
    {
        private readonly IEmployeeService employeeService;
        private readonly IMapper mapper;

        public EmployeeQueryHandler(IEmployeeService employeeService, IMapper mapper)
        {
            this.employeeService = employeeService;
            this.mapper = mapper;
        }

        public async Task<Response<List<GetEmployeeListDTO>>> Handle(GetEmployeeListQuery request, CancellationToken cancellationToken)
        {
            var employeeList = await employeeService.GetAllAsync();
            var emloyeeListDTO = mapper.Map<List<GetEmployeeListDTO>>(employeeList);
            return Success(emloyeeListDTO);
        }

        public async Task<Response<GetEmployeeByIdDTO>> Handle(GetEmployeeByIdQuery request, CancellationToken cancellationToken)
        {
            var employee = await employeeService.GetByIdIncludeDepartmentAsync(request.Id);
            if (employee == null)
                return NotFound<GetEmployeeByIdDTO>();
            var employeeDTO = mapper.Map<GetEmployeeByIdDTO>(employee);
            return Success(employeeDTO);
        }

        public async Task<PaginatedResult<GetEmployeePaginatedListDTO>> Handle(GetEmployeePaginatiedListQuery request, CancellationToken cancellationToken)
        {
            Expression<Func<Employee, GetEmployeePaginatedListDTO>> expression = (e => new GetEmployeePaginatedListDTO() { Id = e.Id, Address = e.Address, Name = e.Name, Phone = e.Phone, DepartmentName = e.Department.Name });

            var queryable = employeeService.FilterPaginationAsQueryable(request.Orders, request.Search);
            var result = await queryable.Select(expression).ToPaginatedListAsync(request.PageNumber, request.PageSize);
            return result;
        }
    }
}
