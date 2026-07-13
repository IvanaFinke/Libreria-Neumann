using LibreriaNeumann.Models;

namespace LibreriaNeumann.Services
{
    public class UserSession
    {
        public User? Usuario { get; set; }
        public event Func<Task>? OnChange; //delegado; es decir; puntero a metodo

        public async Task SetUser(User user)
        {
            Usuario = user;
            await NotificarCambio();
        }

        public async Task LogOut()
        {
            Usuario = null;
            await NotificarCambio();
        }

        public async Task NotificarCambio()
        {
            if(OnChange != null) //si hay algun metodo suscrito al evento OnChange
            {
                await OnChange.Invoke();
            }
        }
    }
}
