using LibreriaNeumann.Data;
using LibreriaNeumann.Models;
using Microsoft.EntityFrameworkCore;
using LibreriaNeumann.Services;
using System.Text;
using System.Collections;

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

        public async Task<Libro?> ObtenerPorNombre(string nombre)
        {
            SlugHelper slugHelper = new SlugHelper();
            var libros = await _context.Libros.ToListAsync();  // EF no puede traducir Regex a SQL, hay que traerlos y comparar en memoria
            return libros.FirstOrDefault(libro => slugHelper.GenerarSlug(libro.Titulo) == nombre);
        }

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
                query = query.Where(libros => libros.Categoria.Contains(filtros.Categoria));
            }

            if(!string.IsNullOrEmpty(filtros.Autor))
            {
                query = query.Where(libros => libros.Autor.Contains(filtros.Autor));
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

        //filtro para evitar que se repitan libros con el mismo titulo, autor y editorial en el csv
        public async Task<bool> ExistePorAutorTituloEditorial(string titulo, string autor, string editorial)
        {
            return await _context.Libros.AnyAsync(libro => libro.Titulo == titulo && libro.Autor == autor && libro.Editorial == editorial);
        }

        public string ExportarCSV(List<Libro> libros)
        {
            var stringBuilder = new StringBuilder();

            stringBuilder.AppendLine("Titulo,Fecha,Autor,Precio,ImageURL,Stock,Descripcion,Categoria,Editorial,cantPaginas");

            foreach(var libro in libros)
            {
                stringBuilder.AppendLine($"{Escapar(libro.Titulo)},{libro.Fecha},{Escapar(libro.Autor)},{libro.Precio.ToString(System.Globalization.CultureInfo.InvariantCulture)}," +
                    $"{Escapar(libro.ImageURL)},{libro.Stock},{Escapar(libro.Descripcion)},{Escapar(libro.Categoria)}," +
                    $"{Escapar(libro.Editorial)},{libro.cantPaginas}");
            }
            return stringBuilder.ToString();
        }

        string Escapar(string? texto)
        {
            if (string.IsNullOrEmpty(texto))
                return "\"\"";

            texto = texto.Replace("\"", "\"\""); // escapa comillas
            texto = texto.Replace("\n", " ");    // elimina saltos de línea
            texto = texto.Replace("\r", " ");

            return $"\"{texto}\"";
        }
    }
}
