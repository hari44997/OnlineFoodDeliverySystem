
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

        public void AddCustomer(Customer customer)
        {
            _context.Customers.Add(customer);
            _context.SaveChanges();
        }

        public void DeleteCustomer(int id)
        {
            var Delcustomer = _context.Customers.FirstOrDefault(c => c.CustomerID == id);
            _context.Customers.Remove(Delcustomer);
            _context.SaveChanges();
            
        }

        public List<Customer> GetAllCustomers()
        {
            return _context.Customers.ToList();
        }

        public Customer GetCustomerById(int id)
        {
            return _context.Customers.FirstOrDefault(g => g.CustomerID == id);
        }

        public int UpdateCustomer(Customer customer)
        {
            var UpdateCus = _context.Customers.FirstOrDefault( c=> c.CustomerID == customer.CustomerID);
            _context.Customers.Update(UpdateCus);
            return _context.SaveChanges();
            
        }


        
    }
}
