using AutoMapper;
using CompanyProject.Core.Features.Employees.Queries.DTOs;
using CompanyProject.Core.Features.Employees.Queries.Models;
using CompanyProject.Core.Responses;
using CompanyProject.Data.Models;
using CompanyProject.Service.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyProject.Core.Features.Employees.Queries.Handlers
{
    public class EmployeeHandler : ResponseHandler, IRequestHandler<GetEmployeeListQuery, Response<List<GitEmployeeListDTO>>>
    {
        private readonly IEmployeeService employeeService;
        private readonly IMapper mapper;

        public EmployeeHandler(IEmployeeService employeeService, IMapper mapper)
        {
            this.employeeService = employeeService;
            this.mapper = mapper;
        }

        public async Task<Response<List<GitEmployeeListDTO>>> Handle(GetEmployeeListQuery request, CancellationToken cancellationToken)
        {
            var employeeList = await employeeService.GetAllAsync();
            var emloyeeListDTO =  mapper.Map<List<GitEmployeeListDTO>>(employeeList);
            return Success(emloyeeListDTO);
        }
    }
}
