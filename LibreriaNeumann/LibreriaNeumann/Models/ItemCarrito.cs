namespace LibreriaNeumann.Models
{
    public class ItemCarrito
    { 
        public required Libro libro { get; set; }
        public int Cantidad { get; set; } = 1;
    }
}
