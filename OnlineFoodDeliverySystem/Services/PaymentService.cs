using OnlineFoodDeliverySystem.Data;
using OnlineFoodDeliverySystem.Exceptions;
using OnlineFoodDeliverySystem.Models;
using OnlineFoodDeliverySystem.Repository;

namespace OnlineFoodDeliverySystem.Services     
{
    public class PaymentService : IPaymentService
    {
        private readonly FoodDbContext _context;

        private readonly IPaymentRepository _paymentRepository;

        public PaymentService(IPaymentRepository paymentRepository)
        {
            _paymentRepository = paymentRepository;
        }

        public async Task<IEnumerable<Payment>> GetAllPaymentsAsync()
        {
            var payments = await _paymentRepository.GetAllPaymentsAsync();
            return payments.ToList();
        }

        public async Task<Payment> GetPaymentByIdAsync(int paymentId)
        {
            var payment = await _paymentRepository.GetPaymentByIdAsync(paymentId);
            if (payment == null)
            {
                throw new NotFoundException($"Payment with id {paymentId} does not exists");
            }
            return payment;

        }

        public async Task AddPaymentAsync(Payment payment)
        {
            var paymentExists = await _paymentRepository.GetPaymentByIdAsync(payment.PaymentID);
            if (paymentExists != null)
            {
                throw new AlreadyExistsException($"Payment with id {payment.PaymentID} already exists");
            }
            await _paymentRepository.AddPaymentAsync(payment);
        }

        public async Task UpdatePaymentAsync(int id, Payment payment)
        {
            var paymentExists = await _paymentRepository.GetPaymentByIdAsync(id);
            if (paymentExists == null)
            {
                throw new NotFoundException($"Payment with id {payment.PaymentID} does not exists");
            }
            await _paymentRepository.UpdatePaymentAsync(id, payment);

        }

        public async Task DeletePaymentAsync(int paymentId)
        {
            var payment = await _paymentRepository.GetPaymentByIdAsync(paymentId);
            if (payment == null)
            {
                throw new NotFoundException($"Payment with id {paymentId} does not exists");
            }
            await _paymentRepository.DeletePaymentAsync(paymentId);
        }
    }
}
