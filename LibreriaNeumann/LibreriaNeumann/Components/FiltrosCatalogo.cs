namespace LibreriaNeumann.Components
{
    public class FiltrosCatalogo
    {
        public List<string> Categorias { get; set; } = new();
        public string? Autor { get; set; }
        public int? AnioDesde { get; set; }
        public int? AnioHasta { get; set; }
        public decimal? PrecioMin { get; set; }
        public decimal? PrecioMax { get; set; }
    }
}
