using System.ComponentModel.DataAnnotations;

namespace Uper.Model
{
    public class Ride
    {
        public int RideId { get; set; }
        [Required]
        [MaxLength(150)]
        public string PickupNumber { get; set; }
        [Required]
        [MaxLength(150)]
        public string DropOffLocation { get; set; }
        [Range(20, 5000)]
        public int Fare { get; set; }
        [Required]
        public string Status { get; set; }
        public int RiderId { get; set; }
        public User? Rider { get; set; }
        public int DriveId { get; set; }
        public User ?Driver { get; set; }
        public Payment? Payement { get; set; }
        public Rating? Rating { get; set; }
    }
}
