using OnlineFoodDeliverySystem.Data;
using OnlineFoodDeliverySystem.Models;

namespace OnlineFoodDeliverySystem.Serivces
{
    public class PaymentService : IPaymentService
    {
        private readonly FoodDbContext _context;

        public PaymentService(FoodDbContext context)
        {
            _context = context;
        }
        public void AddPayment(Payment payment)
        {
            throw new NotImplementedException();
        }

        public void DeletePayment(int id)
        {
            throw new NotImplementedException();
        }

        public Payment GetPaymentById(int id)
        {
            throw new NotImplementedException();
        }

        public Payment GetPaymentByMethod(string method)
        {
            throw new NotImplementedException();
        }

        public List<Payment> GetPayments()
        {
            throw new NotImplementedException();
        }

        public void UpdatePaymentStatus(int id, string status)
        {
            throw new NotImplementedException();
        }
    }
}
