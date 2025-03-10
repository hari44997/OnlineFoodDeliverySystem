using OnlineFoodDeliverySystem.Data;
using OnlineFoodDeliverySystem.Models;

namespace OnlineFoodDeliverySystem.Repository
{
    public class PaymentRepository : IPaymentRepository
    {
        private readonly FoodDbContext _context;

        public PaymentRepository(FoodDbContext context)
        {
            _context = context;
        }
        public Payment GetPaymentById(int id)
        {
            return _context.Payments.Find(id);
        }

        public Payment GetPaymentByMethod(string method)
        {
            return _context.Payments.FirstOrDefault(p => p.PaymentMethod == method);
        }

        public List<Payment> GetPayments()
        {
            return _context.Payments.ToList();
        }
    }
}
