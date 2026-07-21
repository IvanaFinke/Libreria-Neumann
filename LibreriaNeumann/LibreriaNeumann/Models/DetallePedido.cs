namespace LibreriaNeumann.Models
{
    public class DetallePedido //clase que guarda un SnapShot del libro en el momento de la compra,
                               //para que si el libro cambia de precio o se elimina, el pedido siga siendo el mismo 
                               //que aquella vez que se guardo, No estariamos guardando el libro, sino referencia al ItemCarrito de ese momento
    {
        public int Id { get; set; }
        public int PedidoId { get; set; }
        public int LibroId { get; set; }
        public string TituloLibro { get; set; } = string.Empty;
        public decimal PrecioUnitario { get; set; }
        public int Cantidad { get; set; }


    }
}
