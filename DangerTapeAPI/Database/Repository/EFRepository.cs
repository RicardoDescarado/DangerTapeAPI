using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace DangerTapeAPI.Database.Repository
{
    public class EFRepository<T> : IRepository<T>
        where T : class
    {
        private readonly DbContext _context;
        private readonly DbSet<T> _dbSet;
        private bool disposed;
        public EFRepository(DbContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }

        public async Task<T> Add(T entity)
        {
            await _dbSet.AddAsync(entity);
            return entity;
        }

        public void Delete(T entity)
        {
            _dbSet.Remove(entity);
        }

        public async Task<T> Get(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public IQueryable<T> GetAll()
        {
            return _dbSet.AsQueryable();
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Update(T entity)
        {
            _dbSet.Update(entity);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposed)
            {
                return;
            }
            if (disposing)
            {
                _context?.Dispose();
            }

            disposed = true;
        }
    }
}