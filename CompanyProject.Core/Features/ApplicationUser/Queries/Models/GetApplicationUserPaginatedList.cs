using CompanyProject.Core.Features.ApplicationUser.Queries.DTOs;
using CompanyProject.Core.Wrabbers;
using MediatR;

namespace CompanyProject.Core.Features.ApplicationUser.Queries.Models
{
    public class GetApplicationUserPaginatedList : IRequest<PaginatedResult<GetApplicationUserDTO>>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }

    }
}
