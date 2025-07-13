using CompanyProject.Core.Responses;
using MediatR;

namespace CompanyProject.Core.Features.ApplicationUser.Commands.Models
{
    public class UpdateApplicationUserCommand : IRequest<Response<string>>
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
    }
}
