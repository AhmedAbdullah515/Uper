using System.ComponentModel.DataAnnotations;

namespace Uper.DTOs
{
    public class LoginDTO
    {
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
