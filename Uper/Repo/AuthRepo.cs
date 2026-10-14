using System.Xml.Linq;
using Microsoft.EntityFrameworkCore;
using Uper.App_Context;
using Uper.Model;

namespace Uper.Repo
{
    public class AuthRepo : IAuthRepo
    {
        public AppDbContext _context;
        public AuthRepo(AppDbContext _Context)
        {
            _context = _Context;
        }
        public async Task<User> GetbyEmail(string email)
        {
          return await _context.users.FirstOrDefaultAsync(u => u.Email == email);
        }

        public async Task Register(User user)
        {
            await _context.users.AddAsync(user);
        }
    }
}
