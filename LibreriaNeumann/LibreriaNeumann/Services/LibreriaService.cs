using LibreriaNeumann.Data;
using LibreriaNeumann.Models;
using Microsoft.EntityFrameworkCore;

namespace LibreriaNeumann.Services
{
    public class LibreriaService
    {
        public readonly AppDbContext _context;
        public LibreriaService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Libreria> ObtenerLibreria()
        {
            var datos = await _context.Libreria.FirstOrDefaultAsync();

            if(datos == null)
            {
                datos = new Libreria();
                _context.Libreria.Add(datos);
                await _context.SaveChangesAsync();
            }

            return datos;
        }
        public async Task ModificarSobreNosotros(string nuevoNosotros)
        {
            var actual = await ObtenerLibreria();
            actual.SobreNosotros = nuevoNosotros;
           await  _context.SaveChangesAsync();
        }

        public async Task ModificarTelefono(string nuevoTel)
        {
            var actual = await ObtenerLibreria();
            actual.Telefono = nuevoTel;
            await _context.SaveChangesAsync();
        }

        public async Task ModificarCalle(string calle, int alturaCalle)
        {
            var actual = await ObtenerLibreria();
            actual.Calle = calle;
            actual.AlturaCalle = alturaCalle;
            await _context.SaveChangesAsync();
        }

        public async Task ModificarEmail(string nuevoMail)
        {
            var actual = await ObtenerLibreria();
            actual.Email = nuevoMail;
            await _context.SaveChangesAsync();
        }

    }
}
