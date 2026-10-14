using System.ComponentModel.DataAnnotations;

namespace Uper.Model
{
    public class Payment
    {
        public int PaymentId { get; set; }
        [Range(20, 5000)]
        public int Amount { get; set; }
        [Required]
        public string PaymentMethod { get; set; }
        [Required]
        public DateTime PaymentDate { get; set; }
        [Required]
        public string Status { get; set; }
        public int RideId { get; set; }
        public Ride? Ride { get; set; }
    }
}
