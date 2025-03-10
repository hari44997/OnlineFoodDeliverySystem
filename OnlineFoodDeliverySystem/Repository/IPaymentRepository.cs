using OnlineFoodDeliverySystem.Models;

namespace OnlineFoodDeliverySystem.Repository
{
    public interface IPaymentRepository
    {
        List<Payment> GetPayments();
        Payment GetPaymentById(int id);
        Payment GetPaymentByMethod(string method);
    }
}
