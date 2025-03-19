using Microsoft.EntityFrameworkCore;
using OnlineFoodDeliverySystem.Data;
using OnlineFoodDeliverySystem.Models;

namespace OnlineFoodDeliverySystem.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly FoodDbContext _context;
        public UserRepository(FoodDbContext context)
        {
            _context = context;
        }

        //User CRUD
        public async Task AddUserAsync(User User)
        {
            await _context.Users.AddAsync(User);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteUserAsync(int id)
        {
            var deleteuser = await _context.Users.FindAsync(id);
            if (deleteuser != null)
            {
                _context.Users.Remove(deleteuser);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<User>> GetAllUsersAsync()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<User> GetUserByEmailAsync(string email)
        {
            return await _context.Users.FirstOrDefaultAsync(x => x.EmailAddress == email);
            
        }

        public async Task<User> GetUserByIdAsync(int id)
        {
            return await _context.Users.FindAsync(id);
        }

        public async Task<IEnumerable<User>> GetUsersByRoleAsync(int role)
        {
            return await _context.Users.Where(x => x.RoleID == role).ToListAsync();
        }


        //Customer CRUD
        public async Task<IEnumerable<Customer>> GetAllCustomersAsync()
        {
            return await _context.Customers.ToListAsync();
        }

        public async Task<Customer> GetCustomerByIdAsync(int customerId)
        {
            return await _context.Customers.FindAsync(customerId);
        }

        public async Task AddCustomerAsync(Customer customer)
        {
            await _context.Customers.AddAsync(customer);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateCustomerAsync(int id, Customer customer)
        {

            var cust = _context.Customers.Find(id);

            cust.Name = customer.Name;
            cust.Email = customer.Email;
            cust.Phone = customer.Phone;
            cust.Address = customer.Address;

            _context.Customers.Update(cust);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteCustomerAsync(int customerId)
        {
            var customer = await _context.Customers.FindAsync(customerId);
            if (customer != null)
            {
                _context.Customers.Remove(customer);
                await _context.SaveChangesAsync();
            }
        }

        //Agent CRUD
        public async Task AddAgentAsync(Agent agent)
        {
            await _context.Agents.AddAsync(agent);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAgentAsync(int id)
        {
            var deleteAgent = await _context.Agents.FindAsync(id);
            if (deleteAgent != null)
            {
                _context.Agents.Remove(deleteAgent);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<Agent> GetAgentByIdAsync(int id)
        {
            var getagent = await _context.Agents.FindAsync(id);
            return getagent;
        }

        public async Task<IEnumerable<Agent>> GetAllAgentsAsync()
        {
            return await _context.Agents.ToListAsync();
        }

        public async Task UpdateAgentAsync(int id, Agent agent)
        {
            var Updateagent = await _context.Agents.FindAsync(id);
            Updateagent.Name = agent.Name;
            _context.Agents.Update(Updateagent);
            await _context.SaveChangesAsync();
        }

        //Admin CRUD
        public async Task AddAdminAsync(Admin admin)
        {
            await _context.Admins.AddAsync(admin);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAdminAsync(int id)
        {
            var deleteAdmin = await _context.Admins.FindAsync(id);
            if (deleteAdmin != null)
            {
                _context.Admins.Remove(deleteAdmin);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<Admin> GetAdminByIdAsync(int id)
        {
            var getAdmin = await _context.Admins.FindAsync(id);
            return getAdmin;
        }

        public async Task<IEnumerable<Admin>> GetAllAdminsAsync()
        {
            return await _context.Admins.ToListAsync();
        }

        public async Task UpdateAdminAsync(int id, Admin admin)
        {
            var UpdateAdmin = await _context.Admins.FindAsync(id);
            UpdateAdmin.AdminName = admin.AdminName;
            _context.Admins.Update(UpdateAdmin);
            await _context.SaveChangesAsync();
        }
    }
}
