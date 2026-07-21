using LibreriaNeumann.Data;
using LibreriaNeumann.Models;
using Microsoft.EntityFrameworkCore;

namespace LibreriaNeumann.Services
{
    public class UserService
    {
        private readonly AppDbContext _context;
        private readonly PasswordHash _hasher;

        public UserService(AppDbContext context, PasswordHash hasher)
        {
            _context = context;
            _hasher = hasher;
        }

        public async Task Update(User usuario)
        {
            _context.Users.Update(usuario);
            await _context.SaveChangesAsync(); 
        }

        public async Task<User?> GetById(int id)
        {
            var usuario = await _context.Users.FirstOrDefaultAsync<User>(u => u.Id == id);
            return usuario;
        }

        public async Task<User?> GetByEmail(string email)
        {
            var usuario = await _context.Users.FirstOrDefaultAsync<User>(u => u.Email == email);
            return usuario;
        }

        public async Task<string> GenerarTokenReset(string email)
        {
            var user = await GetByEmail(email);
            if (user != null)
            {
                var token = Convert.ToBase64String(Guid.NewGuid().ToByteArray()).Replace("/", "_").Replace("+", "-"); //evitar problemas de url
                user.TokenPassword = token;
                user.TokenExpiracion = DateTime.UtcNow.AddHours(1); //tiempo limite
                await _context.SaveChangesAsync();
                return token;
            }
            else
            {
                return null!;
            }

        }

        public async Task<bool> ResetPassword(string token,string nuevaContra)
        {
            var user = await _context.Users.FirstOrDefaultAsync(usuario => usuario.TokenPassword == token && usuario.TokenExpiracion > DateTime.UtcNow);
            if (user == null) return false; //token invalido o expirado
            user.HashPassword = _hasher.Hash(nuevaContra);
            user.TokenPassword = null;
            user.TokenExpiracion = null;
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
