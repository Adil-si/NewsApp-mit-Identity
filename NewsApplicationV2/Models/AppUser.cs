using Microsoft.AspNetCore.Identity;

namespace NewsApplicationV2.Models
{
    public class AppUser : IdentityUser
    {
        public virtual ICollection<Article> Articles { get; set; } = [];

        public virtual ICollection<AppUserRole> UserRoles { get; set; } = [];
    }
}
