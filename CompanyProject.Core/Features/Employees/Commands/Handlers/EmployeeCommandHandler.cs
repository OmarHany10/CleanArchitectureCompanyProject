using AutoMapper;
using CompanyProject.Core.Features.Employees.Commands.Models;
using CompanyProject.Core.Responses;
using CompanyProject.Data.Models;
using CompanyProject.Service.Interfaces;
using MediatR;

namespace CompanyProject.Core.Features.Employees.Commands.Handlers
{
    public class EmployeeCommandHandler : ResponseHandler,
                                          IRequestHandler<AddEmployeeComand, Response<string>>,
                                          IRequestHandler<EditEmployeeComand, Response<string>>

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

            if (result != null)
                return BadRequest<string>(result);

            return Created("Added Succefuly");
        }

        public async Task<Response<string>> Handle(EditEmployeeComand request, CancellationToken cancellationToken)
        {
            var employee = mapper.Map<Employee>(request);

            var result = await employeeService.EditAsync(employee);

            if (result != null)
            {
                if (result == "Not Found")
                    return NotFound<string>($"There are no employee having this Id => {request.Id}");
                else
                    return BadRequest<string>(result);
            }

            return Success<string>("Edited Successfuly");
        }
    }
}
