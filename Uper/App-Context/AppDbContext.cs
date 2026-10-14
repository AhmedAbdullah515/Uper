using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Uper.Model;

namespace Uper.App_Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        public DbSet<User> users { get; set; }
        public DbSet<Vehicle> vehicles { get; set; }
        public DbSet<Ride> rides { get; set; }
        public DbSet<Payment> payments { get; set; }
        public DbSet<Rating> Ratings { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasOne(a => a.DriverVehicle).WithOne(a => a.Driver)
                .HasForeignKey<Vehicle>(a => a.DriverId).OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<Ride>().HasOne(a => a.Driver).WithMany(a => a.DriverRides)
                .HasForeignKey(a => a.DriveId).OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<Ride>().HasOne(a => a.Rider).WithMany(a => a.RiderRides).
                HasForeignKey(a => a.RiderId).OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<Ride>().HasOne(a=>a.Payement).WithOne(a => a.Ride)
                .HasForeignKey<Payment>(a => a.RideId).OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<Ride>().HasOne(a => a.Rating).WithOne(a => a.Ride)
                .HasForeignKey<Rating>(a => a.RideId).OnDelete(DeleteBehavior.NoAction);
            //Keys
            modelBuilder.Entity<User>().HasKey(a => a.UserId);
            modelBuilder.Entity<Vehicle>().HasKey(a => a.VehicleId);
            modelBuilder.Entity<Ride>().HasKey(a => a.RideId);
            modelBuilder.Entity<Payment>().HasKey(a => a.PaymentId);
            modelBuilder.Entity<Rating>().HasKey(a => a.RatingId);
            //Data seeding
            modelBuilder.Entity<User>().HasData(
                new User { UserId = 1, FullName = "Ahmed abdullah", Email = "elldeegahmag@gmail.com", Phone = "01129566806", Password = "123456", Role = "Driver" },
                new User { UserId = 2, FullName = "Ali abdullah", Email = "Ali@gmail.com", Phone = "01129569806", Password = "12399956", Role = "Rider" }
                );
            modelBuilder.Entity<Vehicle>().HasData(
                new Vehicle { VehicleId = 1, PlateNumber = "123456", Color = "Red", DriverId = 1 }
                );
            modelBuilder.Entity<Ride>().HasData(
                new Ride { RideId = 1, PickupNumber = "Cairo", DropOffLocation = "Giza", Fare = 100, Status = "Completed", RiderId = 2, DriveId = 1 }
                );
            modelBuilder.Entity<Payment>().HasData(
                new Payment { PaymentId = 1, Amount = 100, PaymentMethod = "Cash",Status="Done", RideId = 1 }
                );
            modelBuilder.Entity<Rating>().HasData(
                new Rating { RatingId = 1, Score = 5, Comment = "Great ride!", RideId = 1 }
                );
        }
    }
      
}
