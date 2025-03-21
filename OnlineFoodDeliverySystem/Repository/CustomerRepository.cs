using Microsoft.EntityFrameworkCore;
using OnlineFoodDeliverySystem.Data;
using OnlineFoodDeliverySystem.Models;

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
            var customerToUpdate = await _context.Customers.FindAsync(id);
            if (customerToUpdate != null)
            {
                customerToUpdate.Name = customer.Name;
                customerToUpdate.Email = customer.Email;
                customerToUpdate.Phone = customer.Phone;
                customerToUpdate.Address = customer.Address;
                customerToUpdate.RoleID = customer.RoleID;

                _context.Customers.Update(customerToUpdate);
                await _context.SaveChangesAsync();
            }
        }

        public async Task DeleteCustomerAsync(int customerId)
        {
            var customerToDelete = await _context.Customers.FindAsync(customerId);
            if (customerToDelete != null)
            {
                _context.Customers.Remove(customerToDelete);
                await _context.SaveChangesAsync();
            }
        }
    }
}