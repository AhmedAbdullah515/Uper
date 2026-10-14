using Uper.App_Context;
using Uper.Model;

namespace Uper.Repo
{
    public class UnitWorkRepo : IUnitOfWork
    {
        private readonly AppDbContext _context;
        public UnitWorkRepo(AppDbContext context,IAuthRepo authRepo, IGenaricRepo<Vehicle> vehicleRepo, IGenaricRepo<User> userRepo, IGenaricRepo<Ride> rideRepo, IGenaricRepo<Rating> ratingRepo, IGenaricRepo<Payment> paymentRepo)
        {
            _context=context;
            AuthRepo = authRepo;
            VehicleRepo = vehicleRepo;
            UserRepo = userRepo;
            RideRepo = rideRepo;
            RatingRepo = ratingRepo;
            PaymentRepo = paymentRepo;
        }

        public IAuthRepo AuthRepo { get; }
        public IGenaricRepo<Vehicle> VehicleRepo { get; }
        public IGenaricRepo<User> UserRepo { get; }
        public IGenaricRepo<Ride> RideRepo { get; }
        public IGenaricRepo<Rating> RatingRepo { get; }
        public IGenaricRepo<Payment> PaymentRepo { get; }

        public void Save()
        {
            _context.SaveChanges();
        }

    }
}
