using System.ComponentModel.DataAnnotations;

namespace EduKidsApi.Dtos
{
    public class UserDto
    {
        [Required]
        public string Email { get; set; } = null!;
        [Required]
        public string? Password { get; set; }

    }
}
