using System.ComponentModel.DataAnnotations;

namespace Uper.Model
{
    public class Vehicle
    {
        public int VehicleId { get; set; }
        [Required]
        [MaxLength(20)]
        public string PlateNumber { get; set; }
        [Required]
        public string Color { get; set; }
        [Required]
        public int DriverId { get; set; }
        public User ?Driver { get; set; }

    }
}
