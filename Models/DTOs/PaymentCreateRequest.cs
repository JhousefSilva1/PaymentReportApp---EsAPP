using System.ComponentModel.DataAnnotations;

namespace PaymentApi.Models.DTOs
{
    public class PaymentCreateRequest
    {
        [Required]
        public Guid CustomerId { get; set; }

        [Required, MaxLength(200)]
        public string ServiceProvider { get; set; } = string.Empty;

        [Required]
        public decimal Amount { get; set; }
    }
}
