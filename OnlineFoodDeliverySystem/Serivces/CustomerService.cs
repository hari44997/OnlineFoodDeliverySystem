using System;
using OnlineFoodDeliverySystem.Data;

namespace OnlineFoodDeliverySystem.Serivces
{
    public class CustomerService : ICustomerService
    {
        private readonly FoodDbContext _context;

        public CustomerService(FoodDbContext context)
        {
            _context = context;
        }

        public int AddCustomer(Customer customer)
        {
            var customer1 = new Customer
            {
                Name = customer.Name,
                Email = customer.Email,
                Phone = customer.Phone,
                Address = customer.Address
            };

            _context.Customers.Add(customer1);
            return  _context.SaveChanges();
        }

        public Customer GetCustomerById(int id)
        {
            return _context.Customers.Find(id);
        }

        public List<Customer> GetAllCustomers()
        {
            return _context.Customers.ToList();
        }


        
        

        public int UpdateCustomer(Customer customer)
        {
            throw new NotImplementedException();
        }

        public int DeleteCustomer(int id)
        {
            throw new NotImplementedException();
        }
    }
    
   
}
