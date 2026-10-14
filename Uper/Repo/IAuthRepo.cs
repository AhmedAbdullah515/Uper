using Uper.Model;

namespace Uper.Repo
{
    public interface IAuthRepo
    {
        public Task<User> GetbyEmail(string email);
        public Task Register(User user);
    }
}
