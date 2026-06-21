using LibreriaNeumann.Models;

namespace LibreriaNeumann.Services
{
    public class CarritoService
    {
        public List<ItemCarrito> Items { get; private set; } = new();
        public event Action? OnChange; //refresco automatico

        public void AgregarLibro(Libro libro)
        {
            AgregarLibroConCantidad(libro, 1);
        }

        public void AgregarLibroConCantidad(Libro libro, int cantidad)
        {
            var item = Items.FirstOrDefault(it => it.libro.Id == libro.Id); //busca repetidos
            if (item != null)
            {
                item.Cantidad += cantidad;
            }
            else
            {
                Items.Add(new ItemCarrito { libro = libro, Cantidad = cantidad }); //nuevo
            }
            NotificarCambio();
        }

        public void EliminarLibro(Libro libro)
        {
            var item = Items.FirstOrDefault(i => i.libro.Id == libro.Id);
            if(item != null)
            {
                Items.Remove(item);
                NotificarCambio();

            }
        }

        public decimal Total => Items.Sum(i => i.libro.Precio * i.Cantidad);

        private void NotificarCambio()
        {
            OnChange?.Invoke();
        }
    }
}
