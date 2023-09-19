using Microsoft.AspNetCore.Identity;

namespace Sample_MinimalAPI.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string Name { get; set; }
    }
}
