using CompanyProject.API.BaseController;
using CompanyProject.Core.Features.ApplicationUser.Commands.Models;
using CompanyProject.Core.Features.ApplicationUser.Queries.Models;
using Microsoft.AspNetCore.Mvc;

namespace CompanyProject.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : AppControllerBase
    {
        [HttpPost("Register")]
        public async Task<IActionResult> Register(AddApplicationUserCommand addApplicationUserCommand)
        {
            var result = await mediator.Send(addApplicationUserCommand);
            return Result(result);
        }

        [HttpGet("Pagination")]
        public async Task<IActionResult> GetPaginated([FromQuery] GetApplicationUserPaginatedList getApplicationUserPaginated)
        {
            var result = await mediator.Send(getApplicationUserPaginated);
            return Ok(result);
        }

        [HttpGet("ByUserName")]
        public async Task<IActionResult> GetByUserName([FromQuery] GetApplicationUserByUsernameQuery getApplicationUserByUsernameQuery)
        {
            var result = await mediator.Send(getApplicationUserByUsernameQuery);
            return Result(result);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateApplicationUserCommand updateApplicationUserCommand)
        {
            var result = await mediator.Send(updateApplicationUserCommand);
            return Result(result);
        }
    }
}
