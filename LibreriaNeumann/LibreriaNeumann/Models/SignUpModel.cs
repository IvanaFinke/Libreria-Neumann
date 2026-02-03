using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace LibreriaNeumann.Models
{
    public class SignUpModel
    {
        [Required]
        [RegularExpression(@"^[A-Z][a-zA-Z]+$", ErrorMessage="Nombre Inválido")]
        public string Nombre { get; set; } = string.Empty;

        [Required]
        [RegularExpression(@"^[A-Z][a-z-A-Z]+$", ErrorMessage ="Apellido Inválido")]
        public string Apellido { get; set; } = string.Empty;

        [Required]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;

        [PasswordPropertyText]
        [Required]
        [MinLength(6)]
        public string Constrasenia { get; set; } = string.Empty;

        [PasswordPropertyText]
        [Required]
        [Compare(nameof(Constrasenia),ErrorMessage = "Las contraseñas no coinciden")]
        public string ConfirmContrasenia { get; set; } = string.Empty;

        public string Rol { get; set; } = "Cliente";

    }
}
