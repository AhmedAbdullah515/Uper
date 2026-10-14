using Uper.Model;

namespace Uper.Repo
{
    public interface IUnitOfWork
    {
        public IAuthRepo AuthRepo { get; }
        public IGenaricRepo<Vehicle> VehicleRepo { get; }
        public IGenaricRepo<User> UserRepo { get; }
        public IGenaricRepo<Ride> RideRepo { get; }
        public IGenaricRepo<Rating> RatingRepo { get; }
        public IGenaricRepo<Payment> PaymentRepo { get; }
        public void Save();

    }
}
