using Microsoft.AspNetCore.Identity;

namespace EduKidsApi.Models
{
    public class User: IdentityUser<Guid>
    {
        public List<Response>? Responses { get; set; }
        public virtual ICollection<IdentityUserClaim<Guid>>? Claims { get; set; }
        public virtual ICollection<IdentityUserLogin<Guid>>? Logins { get; set; }
        public virtual ICollection<IdentityUserToken<Guid>>? Tokens { get; set; }
        public virtual ICollection<UserRole>? UserRoles { get; set; }
    }
}
