using Internship_Netsol_ProductManagement_DotNetApi.Models;
using System.Threading.Tasks;

namespace Internship_Netsol_ProductManagement_DotNetApi.Interfaces
{
    public interface IUserRepository
    {
        Task<User> CreateUserAsync(User user);
        Task<bool> UserAuthenticationAsync(string email, string password);
        Task<User> GetUserByIdAsync(int id);
    }
}
