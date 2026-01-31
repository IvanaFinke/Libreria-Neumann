namespace LibreriaNeumann.Services
{
    public class FiltrosCatalogo
    {
        public string? Categoria { get; set; }
        public string? Autor { get; set; }
        public int? FechaMin { get; set; }
        public int? FechaMax { get; set; }
        public decimal? PrecioMin { get; set; }
        public decimal? PrecioMax { get; set; }
    }
}
