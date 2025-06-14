using AutoMapper;
using CompanyProject.Core.Features.Employees.Commands.Models;
using CompanyProject.Core.Responses;
using CompanyProject.Data.Models;
using CompanyProject.Service.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyProject.Core.Features.Employees.Commands.Handlers
{
    public class EmployeeCommandHandler : ResponseHandler, IRequestHandler<AddEmployeeComand, Response<string>>
    {
        private readonly IEmployeeService employeeService;
        private readonly IMapper mapper;

        public EmployeeCommandHandler(IEmployeeService employeeService, IMapper mapper)
        {
            this.employeeService = employeeService;
            this.mapper = mapper;
        }


        public async Task<Response<string>> Handle(AddEmployeeComand request, CancellationToken cancellationToken)
        {
            var employee = mapper.Map<Employee>(request);

            var result = await employeeService.AddAsync(employee);
            
            if(result != null)
                return BadRequest<string>(result);

            return Created("Added Succefuly");
        }
    }
}
