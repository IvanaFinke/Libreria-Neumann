using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace LibreriaNeumann.Models
{
    public class SignUpModel
    {
        public string Nombre { get; set; } = string.Empty;
        public string Apellido { get; set; } = string.Empty;

        [EmailAddress]
        public string Email { get; set; } = string.Empty;

        [PasswordPropertyText]
        public string Constrasenia { get; set; } = string.Empty;

        [PasswordPropertyText]
        public string ConfirmContrasenia { get; set; } = string.Empty;

        public string Rol { get; set; } = "Cliente";

    }
}
