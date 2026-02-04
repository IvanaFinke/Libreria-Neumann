using System.ComponentModel.DataAnnotations;

namespace LibreriaNeumann.Models
{
    public class Libro
    {
        [Key]
        public int Id { get; set; }

        public required string Titulo { get; set; }

        public required int Fecha { get; set; }

        public required string Autor { get; set; }

        [Range(0,9999999.9)]
        [DataType(DataType.Currency)]
        public required decimal Precio { get; set; }

        public required string ImageURL { get; set; }

        [Range(0,9999999.9)]
        [DataType(DataType.Currency)]
        public decimal PrecioCuotas { get; set; }

        [Range(0, int.MaxValue)]
        public required int Stock { get; set; }

        [MaxLength(4000)]
        public required string Descripcion { get; set; }

        public required string Categoria { get; set; }

        public required string Editorial { get; set; }

        [Range(1,int.MaxValue)]
        public required int cantPaginas { get; set; }
    }
}
