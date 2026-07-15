using LibreriaNeumann.Migrations;
using LibreriaNeumann.Models;

namespace LibreriaNeumann.Services
{
    public class ProcesadorPagosService
    {
        public void GenerarCodigoOperacion(Pedido pedido)
        {
            // Genera un código de operación único para el pedido
            pedido.CodigoOperacion = Guid.NewGuid();
        }

        public void ProcesarDatos(Pedido pedido)
        {

        }

        public async Task<string?> VerificarTelefono(Pedido pedido, UserService servicioUsuario)
        {
            var usuario = await servicioUsuario.GetByEmail(pedido.UsuarioId.ToString());
            if (!(usuario!.telefono.StartsWith("11") || usuario.telefono.StartsWith("011")))
            {
                return "El número de teléfono no es válido. Debe comenzar con '11' o '011'";
            }
            else if (usuario.telefono.Length != 10)
            {
                return "El número de teléfono debe tener exactamente 10 dígitos.";
            }
            else
            {
                return null; // El número de teléfono es válido
            }
        }
        public async Task<string?> VerificarDireccion(Pedido pedido, UserService servicioUsuario)
        {
            var usuario = await servicioUsuario.GetByEmail(pedido.UsuarioId.ToString());
            if (string.IsNullOrEmpty(usuario!.provincia) || string.IsNullOrEmpty(usuario.localidad) || string.IsNullOrEmpty(usuario.calle) || string.IsNullOrEmpty(usuario.alturaCalle))
            {
                return "La dirección no es válida. Todos los campos de dirección deben estar completos.";
            }
            else
            {
                return null; // La dirección es válida
            }
        }
    }
}
