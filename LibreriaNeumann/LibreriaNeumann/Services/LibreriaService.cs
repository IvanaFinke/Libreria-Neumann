using LibreriaNeumann.Data;
using LibreriaNeumann.Models;
using Microsoft.EntityFrameworkCore;

namespace LibreriaNeumann.Services
{
    public class LibreriaService
    {
        /*usamos una fabrica para que cuando necesitemos del servicio dentro de una misma pagina (ej en parte
        del contenido y en el footer llamando a una misma funcion el contexto no tenga llamadas simultaneas que
        puedan quedar colgadas. Fabricas son instancias que se crean y se eliminan una vez usadas*/
        public readonly IDbContextFactory<AppDbContext> _contextFactory;
        public event Func<Task>? OnChange;
        public LibreriaService(IDbContextFactory<AppDbContext> contextFactory)
        {
            _contextFactory = contextFactory;
        }

        public async Task<Libreria> ObtenerLibreria()
        {
            await using var _context = await _contextFactory.CreateDbContextAsync();

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
            await using var _context = await _contextFactory.CreateDbContextAsync();

            var actual = await ObtenerLibreria();
            actual.SobreNosotros = nuevoNosotros;
           await  _context.SaveChangesAsync();
        }

        public async Task ModificarTelefono(string nuevoTel)
        {
            await using var _context = await _contextFactory.CreateDbContextAsync();

            var actual = await ObtenerLibreria();
            actual.Telefono = nuevoTel;
            await _context.SaveChangesAsync();
        }

        public async Task ModificarCalle(string calle, int alturaCalle)
        {
            await using var _context = await _contextFactory.CreateDbContextAsync();

            var actual = await ObtenerLibreria();
            actual.Calle = calle;
            actual.AlturaCalle = alturaCalle;
            await _context.SaveChangesAsync();
        }

        public async Task ModificarEmail(string nuevoMail)
        {
            await using var _context = await _contextFactory.CreateDbContextAsync();

            var actual = await ObtenerLibreria();
            actual.Email = nuevoMail;
            await _context.SaveChangesAsync();
        }

        public async Task<bool> ModificarLibreria(Libreria nueva)
        {
            await using var _context = await _contextFactory.CreateDbContextAsync();

            var actual = await _context.Libreria.FirstOrDefaultAsync();

            if (actual == null) return false;

            actual.Telefono = nueva.Telefono ?? actual.Telefono;
            actual.Email = nueva.Email ?? actual.Email;
            actual.Calle = nueva.Calle ?? actual.Calle;
            actual.AlturaCalle = nueva.AlturaCalle ?? actual.AlturaCalle;
            actual.Instagram = nueva.Instagram ?? actual.Instagram;
            actual.Facebook = nueva.Facebook ?? actual.Facebook;
            actual.Tiktok = nueva.Tiktok ?? actual.Tiktok;
            actual.HoraInicio = nueva.HoraInicio ?? actual.HoraInicio;
            actual.HoraSalida = nueva.HoraSalida ?? actual.HoraSalida;
            // SobreNosotros lo dejamos afuera a propósito — se edita desde su propia página

            await _context.SaveChangesAsync();
            await NotificarCambio();
            return true;
        }

        public async Task NotificarCambio()
        {
            if(OnChange != null)
            {
                await OnChange.Invoke();
            }
        }
    }
}
