namespace OnlineFoodDeliverySystem.Serivces
{
    public interface ICustomerService
    {
        List<Customer> GetAllCustomers();
        Customer GetCustomerById(int id);
        void AddCustomer(Customer customer);
        int UpdateCustomer(Customer customer);
        void DeleteCustomer(int id);
    }
}
