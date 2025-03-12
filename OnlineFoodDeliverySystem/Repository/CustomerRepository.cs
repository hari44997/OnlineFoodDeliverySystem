
using Microsoft.EntityFrameworkCore;
using OnlineFoodDeliverySystem.Data;

namespace OnlineFoodDeliverySystem.Repository
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly FoodDbContext _context;
        public CustomerRepository(FoodDbContext context)
        {
            _context = context;
        }

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

            var cust=_context.Customers.Find(id);
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
    }
}

