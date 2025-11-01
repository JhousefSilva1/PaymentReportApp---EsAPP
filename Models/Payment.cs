using System;
using System.ComponentModel.DataAnnotations;

namespace PaymentApi.Models
{
    public class Payment
    {
        [Key]
        public Guid PaymentId { get; set; } = Guid.NewGuid();

        [Required]
        public Guid CustomerId { get; set; }

        [Required]
        [MaxLength(200)]
        public string ServiceProvider { get; set; } = string.Empty;

        [Required]
        [Range(0.01, 1500, ErrorMessage = "El monto debe ser menor o igual a 1500 Bs.")]
        public decimal Amount { get; set; }

        [Required]
        public string Status { get; set; } = "pendiente";

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
