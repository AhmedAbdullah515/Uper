namespace Uper.Repo
{
    public interface IGenaricRepo<T> where T : class
    {
        public Task Add(T entity);
        public Task <IEnumerable<T>> GetAll();
        public Task<T> GetById(int id);
        public void Delete(int id);
        public void Update(T entity);
    }
}
