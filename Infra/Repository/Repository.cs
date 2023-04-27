using Microsoft.EntityFrameworkCore;

namespace Infra.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly DbContext _dbContext;

        public Repository(DbContext dbContext)
        {
            this._dbContext = dbContext;
        }

        public IQueryable<T> GetAll()
        {
            return _dbContext.Set<T>().AsQueryable();
        }

        public async Task<T> InsertReturnAsync(T Entity)
        {
            T newEntity = _dbContext.Set<T>().Add(Entity).Entity;
            var result = await _dbContext.SaveChangesAsync();
            if (result > 0)
            {
                return newEntity;
            }
            else
            {
                return null;
            }
        }

        public async Task<T> UpdateAsync(T Entity)
        {
            try
            {
                _dbContext.Entry(Entity).State = EntityState.Modified;
                _dbContext.Set<T>().Attach(Entity);
                _dbContext.Entry(Entity).State = EntityState.Modified;

                var result = await _dbContext.SaveChangesAsync();
                if (result > 0)
                {
                    return Entity;
                }
                else
                {
                    return null;
                }
            }
            catch
            {
                throw;
            }
        }

        public T GetById(int id)
        {
            return _dbContext.Set<T>().Find(id);
        }

        public int Delete(T Entity)
        {
            _dbContext.Set<T>().Remove(Entity);
            return _dbContext.SaveChanges();
        }

        public void Dispose(bool disposing)
        {
            if (disposing)
            {
                _dbContext.Dispose();
            }
            this.Dispose(disposing);
        }
    }
}
