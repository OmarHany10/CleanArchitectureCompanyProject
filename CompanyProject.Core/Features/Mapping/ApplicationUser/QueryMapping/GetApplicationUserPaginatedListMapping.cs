using CompanyProject.Core.Features.ApplicationUser.Queries.DTOs;

namespace CompanyProject.Core.Features.Mapping.ApplicationUser
{
    public partial class ApplicationUserProfile
    {
        public void GetApplicationUserPaginatedListMapping()
        {
            CreateMap<Data.Models.ApplicationUser, GetApplicationUserDTO>()
                .ForMember(dst => dst.Phone, opt => opt.MapFrom(src => src.PhoneNumber));
        }
    }
}
