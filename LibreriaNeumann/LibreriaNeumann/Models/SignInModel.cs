using System.ComponentModel.DataAnnotations;

namespace LibreriaNeumann.Models
{
    public class SignInModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; } = "";

        [Required]
        [MinLength(6)]
        public string Password { get; set; } = "";
    }
}
