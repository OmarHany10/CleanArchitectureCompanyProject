using CompanyProject.Core.Responses;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace CompanyProject.Core.Features.ApplicationUser.Commands.Models
{
    public class ChangeApplicationUserPasswordCommand : IRequest<Response<string>>
    {
        public string Id { get; set; }

        [DataType(DataType.Password)]
        public string OldPassword { get; set; }

        [DataType(DataType.Password)]
        public string NewPassword { get; set; }

        [DataType(DataType.Password)]
        [Compare(nameof(NewPassword))]
        public string ConfirmNewPassword { get; set; }

    }
}
