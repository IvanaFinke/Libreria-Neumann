namespace LibreriaNeumann.Models
{
    public class Pedido
    {
        public int Id { get; set; }
        public int UsuarioId { get; set; }
        public List<DetallePedido>? Detalles { get; set; }
        public decimal Total { get; set; }
        public EstadoPedido Estado { get; set; } //tiene un enum con estados como  Pendiente,Enviado,entregado,Cancelado
        public Guid CodigoOperacion { get; set; }
        public DateTime FechaCreacion { get; set; }
        public MedioPago? MedioPago { get; set; } //tiene un enum con tipos de pago como Efectivo, TarjetaCredito, TransferenciaBancaria
        public string? Metadata { get; set; } //JSON serializado 
        public int Telefono { get; set; }
        public string Provincia { get; set; } = string.Empty;
        public string Localidad { get; set; } = string.Empty;   
        public string Calle { get; set; } = string.Empty;
        public int AlturaCalle { get; set; }
    }
}
