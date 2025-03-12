namespace OnlineFoodDeliverySystem.Services
{
    public interface ICustomerService
    {
        Task<IEnumerable<Customer>> GetAllCustomersAsync();
        Task<Customer> GetCustomerByIdAsync(int customerId);
        Task AddCustomerAsync(Customer customer);
        Task UpdateCustomerAsync(int id,Customer customer);
        Task DeleteCustomerAsync(int customerId);
    }

}