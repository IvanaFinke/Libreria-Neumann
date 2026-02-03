using Microsoft.IdentityModel.Tokens;

namespace LibreriaNeumann.Models
{
    public class Validations
    {
        /*Debe de empezar con mayusculas y le sigue minusculas. No debe de contener numeros ni caracteres especiales*/
        public string pattern = @"^([A-Z]){1}[a-z]&&\D)";
        /*Sin espacios en blanco, sin 2 @ y que permita .com, .yahoo*/
        public string patternMail = @"\S&&[^@]{2}[.com]||[.yahoo]||[.live]\$";

        public void ValidateName(SignUpModel usuario)
        {
            if(usuario.Nombre.IsNullOrEmpty())
            {
                Console.WriteLine("Falta rellenar este campo");
            }
            else if (usuario.Nombre.IsMatch(pattern))
            {
                Console.WriteLine("Formato no válido");
            }
        }

        public void ValidateSurname(SignUpModel usuario)
        {
            if (usuario.Apellido.IsNullOrEmpty())
            {
                Console.WriteLine("Falta rellenar este campo");
            }
            else if (usuario.Apellido.IsMatch(pattern))
            {
                Console.WriteLine("Formato no válido");
            }
        }

        public void ValidateEmail(SignUpModel usuario)
        {
            if (usuario.Email.IsNullOrEmpty())
            {
                Console.WriteLine("Falta rellenar este campo");
            }
            else if (usuario.Email.IsMatch(patternMail))
            {
                Console.WriteLine("Formato no válido");
            }
        }

        public void ValidatePassword(SignUpModel usuario)
        {
            if (usuario.Constrasenia.IsNullOrEmpty())
            {
                Console.WriteLine("Falta rellenar este campo");
            }
            else if (usuario.Constrasenia.Length < 6)
            {
                Console.WriteLine("La contraseña debe de ser más larga");
            }
        }

        public void ValidateConfirmPassword(SignUpModel usuario)
        {
            if(usuario.ConfirmContrasenia.Length < 6)
            {
                Console.WriteLine("La contraseña debe de ser más larga");
            }
            else if(!usuario.ConfirmContrasenia.Equals(usuario.Constrasenia)
            {
                Console.WriteLine("Las constraseñas no coinciden");
            }
        }
    }
}
