using LibreriaNeumann.Data;
using LibreriaNeumann.Models;
using Microsoft.EntityFrameworkCore;
using LibreriaNeumann.Services;

namespace LibreriaNeumann.Services
{
    public class LibroService
    {
        public readonly AppDbContext _context;

        public LibroService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Libro>> ObtenerLibros() => await _context.Libros.ToListAsync();

        public async Task<Libro?> ObtenerPorId(int id) => await _context.Libros.FindAsync(id);

        public async Task Add(Libro libro)
        {
            _context.Libros.Add(libro);
            await _context.SaveChangesAsync();

        }

        public async Task Delete(int id)
        {
           var libro = await ObtenerPorId(id);
            if(libro is null)
            {
                return;
            }
            _context.Libros.Remove(libro);
            await _context.SaveChangesAsync();
        }

        public async Task Update(Libro libro)
        {
            _context.Libros.Update(libro);
            await _context.SaveChangesAsync();
        }

        /*Filtros de las categorias*/
       public async Task<List<Libro>> Filtros(FiltrosCatalogo filtros)
        {
            var query = _context.Libros.AsQueryable();

            if(!string.IsNullOrEmpty(filtros.Categoria))
            {
                query = query.Where(libros => libros.Categoria == filtros.Categoria);
            }

            if(!string.IsNullOrEmpty(filtros.Autor))
            {
                query = query.Where(libros => libros.Autor == filtros.Autor);
            }

            if(filtros.FechaMin.HasValue)
            {
                query = query.Where(libros => libros.Fecha >= filtros.FechaMin);
            }

            if(filtros.FechaMax.HasValue)
            {
                query = query.Where(libros => libros.Fecha <= filtros.FechaMax);
            }

            if(filtros.PrecioMin.HasValue)
            {
                query = query.Where(libros => libros.Precio >= filtros.PrecioMin);
            }

            if(filtros.PrecioMax.HasValue)
            {
                query = query.Where(libros => libros.Precio <= filtros.PrecioMax);
            }

            return await query.ToListAsync();
        }
    }
}
