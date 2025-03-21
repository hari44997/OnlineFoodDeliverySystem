using Microsoft.EntityFrameworkCore;
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

        public async Task<IEnumerable<Payment>> GetAllPaymentsAsync()
        {
            return await _context.Payments.ToListAsync();
        }

        public async Task<Payment> GetPaymentByIdAsync(int paymentId)
        {
            return await _context.Payments.FindAsync(paymentId);
        }

        public async Task AddPaymentAsync(Payment payment)
        {
            await _context.Payments.AddAsync(payment);
            await _context.SaveChangesAsync();
        }

        public async Task UpdatePaymentAsync(int id, Payment payment)
        {
            var paymentToUpdate = await _context.Payments.FindAsync(id);
            if (paymentToUpdate != null)
            {
                paymentToUpdate.PaymentMethod = payment.PaymentMethod;
                paymentToUpdate.Amount = payment.Amount;
                paymentToUpdate.Status = payment.Status;
                _context.Payments.Update(paymentToUpdate);
                await _context.SaveChangesAsync();
            }
        }

        public async Task DeletePaymentAsync(int paymentId)
        {
            var paymentToDelete = await _context.Payments.FindAsync(paymentId);
            if (paymentToDelete != null)
            {
                _context.Payments.Remove(paymentToDelete);
                await _context.SaveChangesAsync();
            }
        }
    }
}