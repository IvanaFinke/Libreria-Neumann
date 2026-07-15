namespace LibreriaNeumann.Models
{
    public class Pedido
    {
        public int Id { get; set; }
        public int UsuarioId { get; set; }
        public List<ItemCarrito>? ItemCarrito { get; set; }
        public decimal Total { get; set; }
        public EstadoPedido Estado { get; set; } //tiene un enum con estados como  Pendiente,Enviado,entregado,Cancelado
        public Guid CodigoOperacion { get; set; }
        public DateTime FechaCreacion { get; set; }
        public MedioPago MedioPago { get; set; } //tiene un enum con tipos de pago como Efectivo, TarjetaCredito, TransferenciaBancaria
    }
}
