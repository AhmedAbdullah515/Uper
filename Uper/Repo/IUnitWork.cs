using Uper.Model;

namespace Uper.Repo
{
    public interface IUnitWork
    {
        IAuthRepo AuthRepo { get; }
        IGenaricRepo<Payment> PaymentRepo { get; }
        IGenaricRepo<Rating> RatingRepo { get; }
        IGenaricRepo<Ride> RideRepo { get; }
        IGenaricRepo<User> UserRepo { get; }
        IGenaricRepo<Vehicle> VehicleRepo { get; }

        void Save();
    }
}