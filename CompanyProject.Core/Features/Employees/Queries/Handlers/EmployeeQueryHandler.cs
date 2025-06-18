using AutoMapper;
using CompanyProject.Core.Features.Employees.Queries.DTOs;
using CompanyProject.Core.Features.Employees.Queries.Models;
using CompanyProject.Core.Responses;
using CompanyProject.Service.Interfaces;
using MediatR;

namespace CompanyProject.Core.Features.Employees.Queries.Handlers
{
    public class EmployeeQueryHandler : ResponseHandler,
        IRequestHandler<GetEmployeeListQuery, Response<List<GetEmployeeListDTO>>>,
        IRequestHandler<GetEmployeeByIdQuery, Response<GetEmployeeByIdDTO>>
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
            var employee = await employeeService.GetByIdAsync(request.Id);
            if (employee == null)
                return NotFound<GetEmployeeByIdDTO>();
            var employeeDTO = mapper.Map<GetEmployeeByIdDTO>(employee);
            return Success(employeeDTO);
        }
    }
}
