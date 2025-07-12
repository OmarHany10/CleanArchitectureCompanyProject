using AutoMapper;
using CompanyProject.Core.Features.ApplicationUser.Commands.Models;
using CompanyProject.Core.Resources;
using CompanyProject.Core.Responses;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Localization;

namespace CompanyProject.Core.Features.ApplicationUser.Commands.Handlers
{
    public class ApplicationUserHandler : ResponseHandler, IRequestHandler<AddApplicationUserCommand, Response<string>>
    {
        private readonly IStringLocalizer<SharedResource> stringLocalizer;
        private readonly UserManager<Data.Models.ApplicationUser> userManager;
        private readonly IMapper mapper;

        public ApplicationUserHandler(IStringLocalizer<SharedResource> stringLocalizer, UserManager<Data.Models.ApplicationUser> userManager, IMapper mapper) : base(stringLocalizer)
        {
            this.stringLocalizer = stringLocalizer;
            this.userManager = userManager;
            this.mapper = mapper;
        }

        public async Task<Response<string>> Handle(AddApplicationUserCommand request, CancellationToken cancellationToken)
        {

            if (await userManager.FindByNameAsync(request.UserName) is not null)
                return BadRequest<string>("Username already exist");

            if (await userManager.FindByEmailAsync(request.Email) is not null)
                return BadRequest<string>("Email already exist");

            var user = mapper.Map<Data.Models.ApplicationUser>(request);

            var result = await userManager.CreateAsync(user, request.Password);

            if (!result.Succeeded)
                return BadRequest<string>(result.Errors.FirstOrDefault().Description);

            return Created<string>(stringLocalizer[SharedResourcesKey.Created]);

        }
    }
}
