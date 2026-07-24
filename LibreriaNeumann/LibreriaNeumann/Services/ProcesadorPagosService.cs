using LibreriaNeumann.Data;
using LibreriaNeumann.Migrations;
using LibreriaNeumann.Models;
using Microsoft.EntityFrameworkCore;

namespace LibreriaNeumann.Services
{
    public class ProcesadorPagosService
    {
        public readonly AppDbContext _context;
        public event Func<Task>? OnChange;

        public ProcesadorPagosService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Pedido>> ObtenerPedidos() => await _context.Pedidos.ToListAsync();

        public Guid GenerarCodigoOperacion()
        {
            // Genera un código de operación único para el pedido
            return Guid.NewGuid();
        }

        /*Funcion que realiza los pedidos*/
        public async Task<string?> ProcesarPedido(Pedido pedido, string? ip, string? userAgent)
        {
            var errorDireccion = VerificarDireccion(pedido);
            if (errorDireccion != null) return errorDireccion;

            var errorTelefono = VerificarTelefono(pedido);
            if (errorTelefono != null) return errorTelefono;

            /*el pedido al ser abonado en tarjeta, en un caso ideal con fondos, es automaticamente aceptado*/
            if (pedido.MedioPago == MedioPago.TarjetaCredito) pedido.Estado = EstadoPedido.Aceptado;

            GenerarMetadata(pedido, ip, userAgent);
            await GuardarPedido(pedido);
            return null; // Pedido procesado correctamente
        }

        public async Task NotificarCambio()
        {
            if (OnChange != null)
            {
                await OnChange.Invoke();
            }
        }

        public string? VerificarTelefono(Pedido pedido)
        {
            if (!(pedido!.Telefono.ToString().StartsWith("11") || pedido.Telefono.ToString().StartsWith("011")))
            {
                return "El número de teléfono no es válido. Debe comenzar con '11' o '011'";
            }
            else if (pedido.Telefono.ToString().Length != 10)
            {
                return "El número de teléfono debe tener exactamente 10 dígitos.";
            }
            else
            {
                return null; // El número de teléfono es válido
            }
        }
        public string? VerificarDireccion(Pedido pedido)
        {
            if (string.IsNullOrEmpty(pedido!.Provincia) || string.IsNullOrEmpty(pedido.Localidad) || string.IsNullOrEmpty(pedido.Calle) || pedido.AlturaCalle == 0)
            {
                return "La dirección no es válida. Todos los campos de dirección deben estar completos.";
            }
            else
            {
                return null; // La dirección es válida
            }
        }

        public void GenerarMetadata(Pedido pedido, string? ip, string? userAgent)
        {
            var data = new
            {
                IP = ip, //direccion ip del cliente
                UserAgent = userAgent, //es el navegador, aplicacion o bots del cliente
                Telefono = pedido.Telefono,
                DireccionCompleta = $"{pedido.Calle} número {pedido.AlturaCalle}, {pedido.Localidad}, {pedido.Provincia}",
                UltimosDigitosTarjeta = pedido.MedioPago == MedioPago.TarjetaCredito ? "****1234" : null,
                FechaOperacion = DateTime.UtcNow
            };

            pedido.Metadata = System.Text.Json.JsonSerializer.Serialize(data);
        }

        public async Task<bool> CambiarEstado(int id, EstadoPedido nuevoEstado)
        {
            var pedido = await _context.Pedidos.FindAsync(id);

            if (pedido == null) { return false; }
            pedido.Estado = nuevoEstado;
            await _context.SaveChangesAsync();
            await NotificarCambio();

            return true;
        }

        public async Task<bool> GuardarPedido(Pedido pedido)
        {
            _context.Pedidos.Add(pedido);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<List<DetallePedido>?> ObtenerDetalles(int id)
        {
            var detalles = await _context.DetallesPedidos.Where(detalle => detalle.PedidoId == id).ToListAsync();
            return detalles;
        }
    }
}
