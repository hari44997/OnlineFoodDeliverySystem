using OnlineFoodDeliverySystem.Models;

namespace OnlineFoodDeliverySystem.Repository
{
    public interface IPaymentRepository
    {
        List<Payment> GetPayments();
        Payment GetPaymentById(int id);
        Payment GetPaymentByMethod(string method);
        void AddPayment(Payment payment);
        void UpdatePaymentStatus(int id, string status);
        void DeletePayment(int id);

    }
}
