using PaymentApi.Data;
using PaymentApi.Models;

namespace PaymentApi.Services
{
    public class PaymentService
    {
        private readonly AppDbContext _context;

        public PaymentService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Payment> RegisterPaymentAsync(Payment payment)
        {
            if (payment.Amount > 1500)
                throw new ArgumentException("El monto no puede ser mayor a 1500 Bs.");

            payment.Status = "pendiente";
            _context.Payments.Add(payment);
            await _context.SaveChangesAsync();

            return payment;
        }

        public async Task<List<Payment>> GetPaymentsByCustomerAsync(Guid customerId)
        {
            var result = _context.Payments
                .Where(p => p.CustomerId == customerId)
                .OrderByDescending(p => p.CreatedAt)
                .ToList();

            return await Task.FromResult(result);
        }
    }
}
