using CompanyProject.API.BaseController;
using CompanyProject.Core.Features.Employees.Commands.Models;
using CompanyProject.Core.Features.Employees.Queries.Models;
using Microsoft.AspNetCore.Mvc;

namespace CompanyProject.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : AppControllerBase
    {

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var result = await mediator.Send(new GetEmployeeListQuery());
            return Result(result);
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> GetById(int Id)
        {
            var result = await mediator.Send(new GetEmployeeByIdQuery(Id));
            return Result(result);
        }

        [HttpPost("AddEmployee")]
        public async Task<IActionResult> Add(AddEmployeeComand comand)
        {
            var result = await mediator.Send(comand);
            return Result(result);
        }

        [HttpPut("EditEmployee")]
        public async Task<IActionResult> Edit(EditEmployeeComand comand)
        {
            var result = await mediator.Send(comand);
            return Result(result);
        }
    }
}
