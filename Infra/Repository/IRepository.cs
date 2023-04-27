namespace Infra.Repository
{
    public interface IRepository<T>
    {
        IQueryable<T> GetAll();
        Task<T> InsertReturnAsync(T Entity);
        Task<T> UpdateAsync(T Entity);
        T GetById(int id);
        int Delete(T Entity);
        void Dispose(bool disposing);
    }
}
