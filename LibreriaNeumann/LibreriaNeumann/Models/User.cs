namespace LibreriaNeumann.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Email { get; set; }
        public string HashPassword { get; set; }
        public string Rol { get; set; }
    }
}
