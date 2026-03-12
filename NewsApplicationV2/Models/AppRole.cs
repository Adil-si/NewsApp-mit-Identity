using Microsoft.AspNetCore.Identity;

namespace NewsApplicationV2.Models
{
    public class AppRole :IdentityRole
    {
        public virtual ICollection<AppUserRole> UserRoles { get; set; } = [];


    }
}
