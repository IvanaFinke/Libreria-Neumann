using static System.Net.WebRequestMethods;
using LibreriaNeumann.Models;

namespace LibreriaNeumann.Data
{
    public class DataSeeder
    {

        public static void Seed(AppDbContext db)
        {
            if (db.Libros.Any()) return;

            db.Libros.Add(new Libro
            {
                Titulo = "TWISTED WONDERLAND N4",
                Autor = "Yana Toboso Wakana Hadzuki Sumire Kowono",
                Fecha = 2024,
                Precio = 16900,
                ImageURL = "https://i.postimg.cc/CM38mrH1/heartslayul-4.webp",
                Editorial = "Planeta Cómic",
                Stock = 10,
                Descripcion = "Yuu es un estudiante de instituto a quien convocan al " +
                "mundo paralelo de Twisted Wonderland 'El país enrevesado de las maravillas-, y que acaba" +
                " convirtiéndose en el supervisor de una residencia desastrada del Instituto Night Raven. ¡La magia y " +
                "las emociones de Riddle, el rector de la casa Heartslabyul, se desbocan y éste sufre una sobremácula! ¿Podrá Yuu " +
                "enfrentarse a Riddle trabajando en equipo con Grimm, Ace, Deuce, Trey y Cater?",
                cantPaginas = 200,
                Categoria = "fantasia",
            });

            db.Libros.Add(new Libro
            {
                Titulo = "EL HOBBIT",
                Autor = "J.R.R. Tolkien",
                Fecha = 1937,
                Precio = 14900,
                ImageURL = "/images/libros/el-hobit.webp",
                Editorial = "Minotauro",
                Stock = 15,
                Descripcion = "Bilbo Bolsón, un hobbit apacible y amante de la comodidad, ve su vida trastornada cuando el " +
                "mago Gandalf y un grupo de enanos llegan a su puerta para reclutarlo en una aventura épica. Su misión: recuperar el" +
                " tesoro robado por el dragón Smaug. A lo largo del viaje, Bilbo enfrenta peligros, descubre su valentía y encuentra un" +
                " misterioso anillo que cambiará su destino y el de la Tierra Media para siempre.",
                cantPaginas = 310,
                Categoria = "fantasia",
            });

            db.Libros.Add(new Libro
            {
                Titulo = "Sherklocke Holmes: Estudio en escarlata",
                Autor = "Arthur Conan Doyle",
                Fecha = 1887,
                Precio = 12900,
                cantPaginas = 250,
                ImageURL = "https://i.postimg.cc/15gXP2xP/01-Portada-Estudio-Escarlata-CAST.jpg",
                Editorial = "Bululu",
                Categoria = "policial",
                Descripcion = "Cuando el Dr. John Watson regresa a Londres tras servir en la guerra de Afganistán, " +
                "se encuentra con un viejo conocido, Sherlock Holmes. Intrigado por las habilidades deductivas de Holmes, " +
                "Watson decide compartir piso con él en el 221B de Baker Street. Juntos, se ven envueltos en un misterioso caso de" +
                " asesinato que desafía toda lógica. A medida que Holmes desentraña pistas y revela secretos ocultos, Watson documenta " +
                "sus aventuras, dando inicio a una legendaria colaboración que revolucionará el género policial.",
                Stock = 8,
            });

            db.Libros.Add(new Libro
            {
                Titulo = "El Conde de Monte Cristo",
                Autor = "Alexandre Dumas",
                Fecha = 1844,
                Precio = 15900,
                cantPaginas = 600,
                ImageURL = "https://i.postimg.cc/x169zPVB/monte-cristo.webp",
                Editorial = "Losada",
                Descripcion = "Edmundo Dantés, un joven marinero prometedor, es traicionado por sus amigos y falsamente acusado de" +
                "ser un agente bonapartista. Encarcelado en el impenetrable castillo de Chateau Dilf, Dantés pasa años planeando su venganza. " +
                " Con la ayuda de un compañero de prisión, descubre un tesoro oculto en la isla de Monte Cristo. ",
                Stock = 9,
                Categoria = "suspenso",
            });

            db.Libros.Add(new Libro
            {
                Titulo = "Alicia en el pais de las maravillas",
                Fecha = 1865,
                Autor = "Lewis Caroll",
                Precio = 20000,
                cantPaginas = 140,
                ImageURL = "/images/libros/alicia.webp",
                Editorial = "Del fondo",
                Stock = 10,
                Descripcion = "'Durante una tarde aburrida, mientras su hermana está bordando debajo de un árbol," +
                " Alicia ve a un conejo blanco, vestido y con un reloj de bolsillo pasando. Ella decide seguirlo por un agujero" +
                " cuando, de repente, cae muy lejos en un mundo de fantasía poblado por peculiares criaturas antropomorfas. El cuento " +
                "juega con la lógica, lo que le da popularidad duradera tanto a los adultos como a los niños. ",
                Categoria = "fantasia",
            });

            db.SaveChanges();
        }
    }
}
