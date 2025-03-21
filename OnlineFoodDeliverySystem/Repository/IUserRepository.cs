using OnlineFoodDeliverySystem.Models;

namespace OnlineFoodDeliverySystem.Repository
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> GetAllUsersAsync();
        Task<User> GetUserByIdAsync(int id);
        Task AddUserAsync(User User);
        Task DeleteUserAsync(int userId);
        Task<User> GetUserByEmailAsync(string email);
        Task<IEnumerable<User>> GetUsersByRoleAsync(int role);

    }
}
