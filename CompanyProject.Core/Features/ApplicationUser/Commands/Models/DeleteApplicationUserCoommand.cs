using CompanyProject.Core.Responses;
using MediatR;

namespace CompanyProject.Core.Features.ApplicationUser.Commands.Models
{
    public class DeleteApplicationUserCoommand : IRequest<Response<string>>
    {
        public string Id { get; set; }
    }
}
