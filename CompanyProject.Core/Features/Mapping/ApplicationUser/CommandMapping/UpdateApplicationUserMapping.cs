using CompanyProject.Core.Features.ApplicationUser.Commands.Models;

namespace CompanyProject.Core.Features.Mapping.ApplicationUser
{
    public partial class ApplicationUserProfile
    {
        public void UpdateApplicationUserMapping()
        {
            CreateMap<UpdateApplicationUserCommand, Data.Models.ApplicationUser>();
        }
    }
}
