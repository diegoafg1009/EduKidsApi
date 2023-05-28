using Microsoft.AspNetCore.Identity;

namespace EduKidsApi.Models
{
    public class User: IdentityUser<Guid>
    {
        public List<ResponseDetail>? ResponseDetails { get; set; }
    }
}
