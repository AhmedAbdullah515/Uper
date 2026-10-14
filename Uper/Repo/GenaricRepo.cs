
using System.Drawing.Text;
using Microsoft.EntityFrameworkCore;
using Uper.App_Context;

namespace Uper.Repo
{
    public class GenaricRepo<T> : IGenaricRepo<T> where T : class
    {
        private readonly AppDbContext _context;
        private readonly DbSet<T> _dbSet;
        public GenaricRepo(AppDbContext cotext)
        {
            _context = cotext;
            _dbSet = _context.Set<T>();
        }
        public async Task Add(T entity)
        {
            await _dbSet.AddAsync(entity);
        }

        public async void Delete(int id)
        {
            var entity=await _dbSet.FindAsync(id);
            if (entity != null)
            {
                _dbSet.Remove(entity);
            }
        }

        public async Task<IEnumerable<T>> GetAll()
        {
           return await _dbSet.ToListAsync();
        }

        public async Task<T> GetById(int id)
        {
           return await _dbSet.FindAsync(id);
        }

        public  void Update(T entity)
        {
             _dbSet.AddAsync(entity);
        }
    }
}
