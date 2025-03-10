namespace OnlineFoodDeliverySystem.Repository
{
    public interface ICustomerRepository
    {
        List<Customer> GetAllCustomers();
        Customer GetCustomerById(int id);
        void AddCustomer(Customer customer);
        int UpdateCustomer(Customer customer);
        void DeleteCustomer(int id);

    }
}
