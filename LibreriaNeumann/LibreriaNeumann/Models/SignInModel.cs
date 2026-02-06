using System.ComponentModel.DataAnnotations;

namespace LibreriaNeumann.Models
{
    public class SignInModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; } = "";

        [Required]
        [MinLength(6,ErrorMessage ="La contraseña debe de tener 6 o más carácteres")]
        public string Password { get; set; } = "";
    }
}
