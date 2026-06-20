using System.Text;

namespace LibreriaNeumann.Services
{
    public class SlugHelper
    {
        public string GenerarSlug(string texto)
        {
            string sinTildes = QuitarTildes(texto);

            return sinTildes.Replace(" ", "-").ToUpper();
        }

        public string QuitarTildes(string texto)
        {
            var normalizado = texto.Normalize(System.Text.NormalizationForm.FormD);
            var sb = new StringBuilder();

            foreach(var c in normalizado)
            {
                var categoria = System.Globalization.CharUnicodeInfo.GetUnicodeCategory(c);
                if (categoria != System.Globalization.UnicodeCategory.NonSpacingMark)
                    sb.Append(c);
            }
            return sb.ToString().Normalize(System.Text.NormalizationForm.FormC);
        }
    }
}
