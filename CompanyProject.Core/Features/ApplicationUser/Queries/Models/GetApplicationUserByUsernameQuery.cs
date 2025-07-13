using CompanyProject.Core.Features.ApplicationUser.Queries.DTOs;
using CompanyProject.Core.Responses;
using MediatR;

namespace CompanyProject.Core.Features.ApplicationUser.Queries.Models
{
    public class GetApplicationUserByUsernameQuery : IRequest<Response<GetApplicationUserDTO>>
    {
        public string UserName { get; set; }
    }
}
