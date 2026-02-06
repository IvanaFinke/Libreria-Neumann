using LibreriaNeumann.Models;

namespace LibreriaNeumann.Services
{
    public class UserSession
    {
        public User? Usuario { get; set; }
        public event Action? OnChange;

        public void SetUser(User user)
        {
            Usuario = user;
            OnChange?.Invoke();
        }

        public void LogOut()
        {
            Usuario = null;
            OnChange?.Invoke();
        }
    }
}
