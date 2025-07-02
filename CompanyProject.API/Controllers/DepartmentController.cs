using CompanyProject.API.BaseController;
using CompanyProject.Core.Features.Departments.Queries.Models;
using Microsoft.AspNetCore.Mvc;

namespace CompanyProject.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : AppControllerBase
    {
        [HttpGet("{Id}")]
        public async Task<IActionResult> GetById(int Id)
        {
            var result = await mediator.Send(new GetDepartmentByIdQuery(Id));
            return Result(result);
        }
    }
}
