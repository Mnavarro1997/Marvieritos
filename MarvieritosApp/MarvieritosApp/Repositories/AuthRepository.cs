using MarvieritosApp.DataBase;
using MarvieritosApp.Interfaces;
using MarvieritosApp.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace MarvieritosApp.Repositories
{
    public class AuthRepository : IAuthReporistory
    {
        private readonly EcommerceDb _context;
        public AuthRepository(EcommerceDb context)
        {
            _context = context;
        }
        public async Task<User> Login(string name, string password)
        {
            var user = await _context.User.FirstOrDefaultAsync(x => x.Name == name); //Get user from database.
            if (user == null)
                return null; // User does not exist.

            if (!VerifyPassword(password, user.PasswordHash, user.Password))
                return null;

            return user;
        }

        private bool VerifyPassword(string password, byte[] passwordHash, byte[] passwordNormal)
        {
            using (var hash = new System.Security.Cryptography.HMACSHA512(passwordNormal))
            {
                var computedHash = hash.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                for (int i = 0; i < computedHash.Length; i++)
                {
                    if (computedHash[i] != passwordHash[i]) return false;
                }
            }
            return true;
        }

        public async Task<User> Register(User user, string password)
        {
            byte[] passwordHash, passwordNormal;
            CreatePasswordHash(password, out passwordHash, out passwordNormal);

            user.PasswordHash = passwordHash;
            user.Password = passwordNormal;

            await _context.User.AddAsync(user); // Adding the user to context of users.
            await _context.SaveChangesAsync(); // Save changes to database.

            return user;
        }

        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordNormal)
        {
            using (var hash = new System.Security.Cryptography.HMACSHA512())
            {
                passwordNormal = hash.Key;
                passwordHash = hash.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }

        public async Task<bool> UserExists(string name)
        {
            if (await _context.User.AnyAsync(x => x.Name == name))
                return true;
            return false;
        }
    }
}
