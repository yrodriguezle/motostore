using Microsoft.EntityFrameworkCore;
using Motostore.DataAccess;
using Motostore.Helpers;
using System.Linq.Expressions;

namespace Motostore.Repositories
{
    public class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        private readonly DbSet<T> _dbSet;
        protected DataContext _dataContext { get; set; }

        public RepositoryBase(DataContext dataContext)
        {
            _dbSet = dataContext.Set<T>();
            _dataContext = dataContext;
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            return await _dbSet.ToListAsync();
        }
        public async Task<IEnumerable<T>> GetFiltered(Expression<Func<T, bool>> expression)
        {
            return await _dbSet.Where(expression).ToListAsync();
        }
        public async Task<T> AddOrUpdate(T entity)
        {
            return await EntityFrameworkHelper.AddOrUpdate(entity, _dataContext);
        }
        public async Task<T?> Delete(T entity)
        {
            return await EntityFrameworkHelper.Delete(entity, _dataContext);
        }
    }
}
