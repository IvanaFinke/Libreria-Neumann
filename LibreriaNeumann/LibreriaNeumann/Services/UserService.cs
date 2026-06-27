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

        public async Task<User?> GetByEmail(string email)
        {
            var usuario = await _context.Users.FirstOrDefaultAsync<User>(u => u.Email == email);
            return usuario;
        }
    }
}
