namespace LibreriaNeumann.Models
{
    public class User
    {
        public int Id { get; set; }
        public required string Nombre { get; set; }
        public required string Apellido { get; set; }
        public required string Email { get; set; }
        public required string HashPassword { get; set; }
        public string Rol { get; set; }
        public string? telefono { get; set; }
        public string? provincia { get; set; }
        public string? localidad { get; set; }
        public string? calle { get; set; }
        public string? alturaCalle { get; set; }
        public string? TokenPassword { get; set; }
        public DateTime? TokenExpiracion { get; set; }
    }
}
