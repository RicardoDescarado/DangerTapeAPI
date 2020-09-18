using System;
using System.Linq;
using System.Threading.Tasks;

namespace DangerTapeAPI.Database.Repository
{
    public interface IRepository<T> :IDisposable
        where T: class
    {
        IQueryable<T> GetAll();

        Task<T> Get(int id);

        Task<T> Add(T entity);

        void Update(T entity);

        void Delete(T entity);

        Task<int> SaveChangesAsync();
    }
}