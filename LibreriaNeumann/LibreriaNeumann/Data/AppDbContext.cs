
using System.Collections.Generic;
using LibreriaNeumann.Models;
using Microsoft.EntityFrameworkCore;

namespace LibreriaNeumann.Data
{
    /*Clase de conexion con la base de datos. 
     Abre la DB, traduce C# a SQL, guarda cambios, trae datos, conoce tablas
    Hereda de DbContext add,delete,update,save,queries,tracking,transactions*/
    public class AppDbContext : DbContext
    {
        /*Creamos la tabla SQL Libros, la cual contiene objetos de tipo Libro*/
        public DbSet<Libro> Libros { get; set; }

        /*Prepara conexion, tracking, provider, tablas, user, passwords,server. Le pasamos
         a la AppDbContext nuestra la configuracion de DbContext con base(options)*/
       public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
    }

}
