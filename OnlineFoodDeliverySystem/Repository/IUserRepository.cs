using OnlineFoodDeliverySystem.Models;

namespace OnlineFoodDeliverySystem.Repository
{
    public interface IUserRepository
    {
        //User
        Task<IEnumerable<User>> GetAllUsersAsync();
        Task<User> GetUserByIdAsync(int id);
        Task AddUserAsync(User User);
        //Task UpdateUserAsync(int id, User user);
        Task DeleteUserAsync(int userId);
        Task<User> GetUserByEmailAsync(string email);
        Task<IEnumerable<User>> GetUsersByRoleAsync(int role);

        //Customer
        Task<IEnumerable<Customer>> GetAllCustomersAsync();
        Task<Customer> GetCustomerByIdAsync(int customerId);
        Task AddCustomerAsync(Customer customer);
        Task UpdateCustomerAsync(int id, Customer customer);
        Task DeleteCustomerAsync(int customerId);

        //Admin
        Task<IEnumerable<Admin>> GetAllAdminsAsync();
        Task<Admin> GetAdminByIdAsync(int id);
        Task AddAdminAsync(Admin admin);
        Task UpdateAdminAsync(int id, Admin admin);
        Task DeleteAdminAsync(int id);

        //Agent
        Task<IEnumerable<Agent>> GetAllAgentsAsync();
        Task<Agent> GetAgentByIdAsync(int id);
        Task AddAgentAsync(Agent agent);
        Task UpdateAgentAsync(int id, Agent agent);
        Task DeleteAgentAsync(int id);
    }
}
