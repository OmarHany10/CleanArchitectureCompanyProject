using CompanyProject.Core.Responses;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace CompanyProject.Core.Features.ApplicationUser.Commands.Models
{
    public class AddApplicationUserCommand : IRequest<Response<string>>
    {
        [MaxLength(50)]
        public string Name { get; set; }

        [MaxLength(50)]
        public string UserName { get; set; }

        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; }

        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Compare(nameof(Password))]
        public string ConfirmPassword { get; set; }

    }
}
