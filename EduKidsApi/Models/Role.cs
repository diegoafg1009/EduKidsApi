using Microsoft.AspNetCore.Identity;

namespace EduKidsApi.Models
{
    public class Role : IdentityRole<Guid>
    {
        public virtual ICollection<UserRole>? UserRoles { get; set; }
    }
}
