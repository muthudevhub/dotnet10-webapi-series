using System.ComponentModel.DataAnnotations;

namespace MyFirstApi.Models
{
    public class LoginRequest
    {
        [Required]
        public string Username { get; set; }

        public string Password { get; set; }
    }
}
