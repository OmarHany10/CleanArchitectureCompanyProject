using CompanyProject.API.BaseController;
using CompanyProject.Core.Features.ApplicationUser.Commands.Models;
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
    }
}
