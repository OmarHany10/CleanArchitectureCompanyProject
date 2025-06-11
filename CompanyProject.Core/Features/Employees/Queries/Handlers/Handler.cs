using CompanyProject.Core.Features.Employees.Queries.Models;
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
    public class Handler : IRequestHandler<GetAllQuery, List<Employee>>
    {
        private readonly IEmployeeService employeeService;

        public Handler(IEmployeeService employeeService)
        {
            this.employeeService = employeeService;
        }

        public async Task<List<Employee>> Handle(GetAllQuery request, CancellationToken cancellationToken)
        {
            return await employeeService.GetAllAsync();
        }
    }
}
