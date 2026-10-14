using System.ComponentModel.DataAnnotations;

namespace Uper.Model
{
    public class User
    {
        public int UserId { get; set; }
        [Required]
        [StringLength(100),MinLength(3)]
        public string FullName { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        [Phone]
        public string Phone { get; set; }
        [Required]
        public string Role { get; set; }
        public Vehicle ?DriverVehicle { get; set; }
        public List<Ride>? DriverRides { get; set; }=new List<Ride>();
        public List<Ride>? RiderRides { get; set; } = new List<Ride>();
    }
}
