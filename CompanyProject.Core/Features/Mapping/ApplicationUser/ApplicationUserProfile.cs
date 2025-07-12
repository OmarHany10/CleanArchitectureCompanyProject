using AutoMapper;

namespace CompanyProject.Core.Features.Mapping.ApplicationUser
{
    public partial class ApplicationUserProfile : Profile
    {
        public ApplicationUserProfile()
        {
            AddApplicationUserMapping();
        }
    }
}
