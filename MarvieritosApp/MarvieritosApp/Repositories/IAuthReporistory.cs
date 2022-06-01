using MarvieritosApp.Models;
using System.Threading.Tasks;

namespace MarvieritosApp.Interfaces
{
    public interface IAuthReporistory
    {
        Task<User> Register(User user, string password);
        Task<User> Login(string username, string pasword);
        Task<bool> UserExists(string username);
    }
}
