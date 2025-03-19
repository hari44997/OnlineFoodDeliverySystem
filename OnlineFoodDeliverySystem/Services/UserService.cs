using OnlineFoodDeliverySystem.Exceptions;
using OnlineFoodDeliverySystem.Models;
using OnlineFoodDeliverySystem.Repository;

namespace OnlineFoodDeliverySystem.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }



        // User Service
        public async Task<IEnumerable<User>> GetAllUsersAsync()
        {
            var users = await _userRepository.GetAllUsersAsync();
            return users.ToList();
        }

        public async Task<User> GetUserByIdAsync(int id)
        {
            User user = await _userRepository.GetUserByIdAsync(id);
            if (user == null)
            {
                throw new NotFoundException($"User with id {id} does not exists");
            }
            return user;
        }

        public async Task AddUserAsync(User user)
        {
            var Adduser = await _userRepository.GetUserByIdAsync(user.UserID);
            if (Adduser != null)
            {
                throw new AlreadyExistsException($"User with {user.UserID} already exists");
            }
            await _userRepository.AddUserAsync(user);

        }

        public async Task UpdateUserAsync(int id, User user)
        {
            var Updateuser = await _userRepository.GetUserByIdAsync(id);
            if (Updateuser == null)
            {
                throw new NotFoundException($"User with {user.UserID} does not exists");
            }

            await _userRepository.GetUserByIdAsync(user.UserID);
        }

        public async Task DeleteUserAsync(int id)
        {
            User DeleteUser = await _userRepository.GetUserByIdAsync(id);
            if (DeleteUser == null)
            {
                throw new NotFoundException($"User with id {id} does not exists");
            }
            await _userRepository.DeleteUserAsync(id);
        }
        public async Task<User> GetUserByEmailAsync(string email)
        {
            User user = await _userRepository.GetUserByEmailAsync(email);
            if (user == null)
            {
                throw new NotFoundException($"User with email {email} does not exists");
            }
            return user;
        }

        public async Task<IEnumerable<User>> GetUsersByRoleAsync(int role)
        {
            var users = await _userRepository.GetUsersByRoleAsync(role);
            if (users == null)
            {
                throw new NotFoundException($"User with role {role} does not exists");
            }
            return users.ToList();
        }


        //Customer Service
        public async Task<IEnumerable<Customer>> GetAllCustomersAsync()
        {
            var customers = await _userRepository.GetAllCustomersAsync();
            return customers.ToList();
        }

        public async Task<Customer> GetCustomerByIdAsync(int customerId)
        {
            Customer customer = await _userRepository.GetCustomerByIdAsync(customerId);
            if (customer == null)
            {
                throw new NotFoundException($"Customer with id {customerId} does not exists");
            }
            return customer;
        }

        public async Task AddCustomerAsync(Customer customer)
        {
            var Addcustomer = await _userRepository.GetCustomerByIdAsync(customer.CustomerID);
            if (Addcustomer != null)
            {
                throw new AlreadyExistsException($"Customer with {customer.CustomerID} already exists");
            }
            await _userRepository.AddCustomerAsync(customer);

        }

        public async Task UpdateCustomerAsync(int id, Customer customer)
        {
            var Updatecustomer = await _userRepository.GetCustomerByIdAsync(id);
            if (Updatecustomer == null)
            {
                throw new NotFoundException($"Customer with {customer.CustomerID} does not exists");
            }

            await _userRepository.UpdateCustomerAsync(id, customer);
        }

        public async Task DeleteCustomerAsync(int customerId)
        {
            Customer Deletecustomer = await _userRepository.GetCustomerByIdAsync(customerId);
            if (Deletecustomer == null)
            {
                throw new NotFoundException($"Customer with id {customerId} does not exists");
            }
            await _userRepository.DeleteCustomerAsync(customerId);
        }


        //Agent Service
        public async Task AddAgentAsync(Agent agent)
        {
            await _userRepository.AddAgentAsync(agent);
        }

        public async Task DeleteAgentAsync(int id)
        {
            Agent deleteAgent = await _userRepository.GetAgentByIdAsync(id);
            if (deleteAgent == null)
            {
                throw new NotFoundException($"Agent wiht id {id} does not exists");
            }
            await _userRepository.DeleteAgentAsync(id);
        }

        public async Task<Agent> GetAgentByIdAsync(int id)
        {
            var getagent = await _userRepository.GetAgentByIdAsync(id);
            if (getagent == null)
            {
                throw new NotFoundException($"Agent with id {id} does not exists");
            }
            return getagent;
        }

        public async Task<IEnumerable<Agent>> GetAllAgentsAsync()
        {
            var getallagents = await _userRepository.GetAllAgentsAsync();
            return getallagents.ToList();
        }

        public async Task UpdateAgentAsync(int id, Agent agent)
        {
            Agent updateAgent = await _userRepository.GetAgentByIdAsync(id);
            if (updateAgent == null)
            {
                throw new NotFoundException($"Agent wiht id {id} does not exists");
            }
            await _userRepository.UpdateAgentAsync(id, agent);
        }


        //Admin Service

        public async Task AddAdminAsync(Admin admin)
        {
            await _userRepository.AddAdminAsync(admin);
        }

        public async Task DeleteAdminAsync(int id)
        {
            Admin deleteAdmin = await _userRepository.GetAdminByIdAsync(id);
            if (deleteAdmin == null)
            {
                throw new NotFoundException($"Admin wiht id {id} does not exists");
            }
            await _userRepository.DeleteAdminAsync(id);
        }

        public async Task<Admin> GetAdminByIdAsync(int id)
        {
            var getAdmin = await _userRepository.GetAdminByIdAsync(id);
            if (getAdmin == null)
            {
                throw new NotFoundException($"Admin with id {id} does not exists");
            }
            return getAdmin;
        }

        public async Task<IEnumerable<Admin>> GetAllAdminsAsync()
        {
            var getallAdmins = await _userRepository.GetAllAdminsAsync();
            return getallAdmins.ToList();
        }

        public async Task UpdateAdminAsync(int id, Admin admin)
        {
            Admin updateAdmin = await _userRepository.GetAdminByIdAsync(id);
            if (updateAdmin == null)
            {
                throw new NotFoundException($"Admin wiht id {id} does not exists");
            }
            await _userRepository.UpdateAdminAsync(id, admin);
        }
    }
}
