using OnlineFoodDeliverySystem.Exceptions;
using OnlineFoodDeliverySystem.Models;
using OnlineFoodDeliverySystem.Repository;

namespace OnlineFoodDeliverySystem.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IUserRepository _userRepository;


        public CustomerService(ICustomerRepository customerRepository, IUserRepository userRepository)
        {
            _customerRepository = customerRepository;
            _userRepository = userRepository;
        }

        public async Task<IEnumerable<Customer>> GetAllCustomersAsync()
        {
            var customers = await _customerRepository.GetAllCustomersAsync();
            return customers.ToList();
        }

        public async Task<Customer> GetCustomerByIdAsync(int customerId)
        {
            Customer customer = await _customerRepository.GetCustomerByIdAsync(customerId);
            if (customer == null)
            {
                throw new NotFoundException($"Customer with id {customerId} does not exists");
            }
            return customer;
        }

        public async Task AddCustomerAsync(Customer customer)
        {
            await _customerRepository.AddCustomerAsync(customer);
            await _userRepository.AddUserAsync(new User { EmailAddress = customer.CustomerEmail, Password = customer.CustomerPassword, RoleID = customer.RoleID });
        }

        public async Task UpdateCustomerAsync(int id, Customer customer)
        {
            var Updatecustomer = await _customerRepository.GetCustomerByIdAsync(id);
            if (Updatecustomer == null)
            {
                throw new NotFoundException($"Customer with {customer.CustomerID} does not exists");
            }

            await _customerRepository.UpdateCustomerAsync(id, customer);
        }

        public async Task DeleteCustomerAsync(int customerId)
        {
            Customer Deletecustomer = await _customerRepository.GetCustomerByIdAsync(customerId);
            if (Deletecustomer == null)
            {
                throw new NotFoundException($"Customer with id {customerId} does not exists");
            }
            await _customerRepository.DeleteCustomerAsync(customerId);
        }
    }
}
