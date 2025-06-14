using CompanyProject.Core.Features.Employees.Commands.Models;
using CompanyProject.Core.Features.Employees.Queries.Models;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CompanyProject.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IMediator mediator;

        public EmployeeController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var result = await mediator.Send(new GetEmployeeListQuery());
            return Ok(result);
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> GetById(int Id)
        {
            var result = await mediator.Send(new GetEmployeeByIdQuery(Id));
            return Ok(result);
        }

        [HttpPost("AddEmployee")]
        public async Task<IActionResult> Add(AddEmployeeComand comand)
        {
            var result = await mediator.Send(comand);
            return Ok(result);
        }
    }
}
