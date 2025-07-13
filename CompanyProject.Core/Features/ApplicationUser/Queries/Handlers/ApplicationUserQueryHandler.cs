using AutoMapper;
using CompanyProject.Core.Features.ApplicationUser.Queries.DTOs;
using CompanyProject.Core.Features.ApplicationUser.Queries.Models;
using CompanyProject.Core.Resources;
using CompanyProject.Core.Responses;
using CompanyProject.Core.Wrabbers;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Localization;

namespace CompanyProject.Core.Features.ApplicationUser.Queries.Handlers
{
    public class ApplicationUserQueryHandler : ResponseHandler,
        IRequestHandler<GetApplicationUserPaginatedList, PaginatedResult<GetApplicationUserDTO>>,
        IRequestHandler<GetApplicationUserByUsernameQuery, Response<GetApplicationUserDTO>>
    {
        private readonly IStringLocalizer<SharedResource> stringLocalizer;
        private readonly IMapper mapper;
        private readonly UserManager<Data.Models.ApplicationUser> userManager;

        public ApplicationUserQueryHandler(IStringLocalizer<SharedResource> stringLocalizer, IMapper mapper, UserManager<Data.Models.ApplicationUser> userManager) : base(stringLocalizer)
        {
            this.stringLocalizer = stringLocalizer;
            this.mapper = mapper;
            this.userManager = userManager;
        }

        public async Task<PaginatedResult<GetApplicationUserDTO>> Handle(GetApplicationUserPaginatedList request, CancellationToken cancellationToken)
        {
            var users = userManager.Users.AsQueryable();
            var pagginatedList = await mapper.ProjectTo<GetApplicationUserDTO>(users).ToPaginatedListAsync(request.PageNumber, request.PageSize);
            return pagginatedList;
        }

        public async Task<Response<GetApplicationUserDTO>> Handle(GetApplicationUserByUsernameQuery request, CancellationToken cancellationToken)
        {
            var user = await userManager.FindByNameAsync(request.UserName);
            if (user == null)
                return NotFound<GetApplicationUserDTO>(stringLocalizer[SharedResourcesKey.NotFound]);

            var result = mapper.Map<GetApplicationUserDTO>(user);
            return Success(result);
        }
    }
}
