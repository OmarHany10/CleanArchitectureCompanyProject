using Microsoft.AspNetCore.Identity;

namespace CompanyProject.Data.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string Name { get; set; }
    }
}
