using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using MOTOSTORE.Helpers;

namespace MOTOSTORE.DataAccess
{
    public interface IRepositoryBase<T>
    {
        Task<IEnumerable<T>> GetAll();
        Task<IEnumerable<T>> GetByFuntionExpression(Expression<Func<T, bool>> whereExpression);
        Task<IEnumerable<T>> GetBySql(string sql);
        Task<T> AddOrUpdate(T entity);
        Task<T> Delete(T entity);
    }
    public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        protected DataContext RepositoryContext { get; set; }
        protected RepositoryBase(DataContext repositoryContext)
        {
            RepositoryContext = repositoryContext;
        }
        public async Task<IEnumerable<T>> GetAll() => await RepositoryContext.Set<T>().Take(Globals.MaxNumberOfrecords).ToListAsync();
        public async Task<IEnumerable<T>> GetByFuntionExpression(Expression<Func<T, bool>> whereExpression) => await RepositoryContext.Set<T>().Where(whereExpression).Take(Globals.MaxNumberOfrecords).ToListAsync();
        public async Task<IEnumerable<T>> GetBySql(string sql) => await RepositoryContext.Set<T>().FromSqlRaw(sql).Take(Globals.MaxNumberOfrecords).ToListAsync();
        public async Task<T> AddOrUpdate(T entity)
        {
            T updatedEntity = await EntityFrameworkHelper.AddOrUpdate(entity, RepositoryContext);
            await RepositoryContext.SaveChangesAsync();
            return updatedEntity;
        }
        public async Task<T> Delete(T entity)
        {
            return await EntityFrameworkHelper.Delete(entity, RepositoryContext);
        }
    }

    public interface IRepositoryWrapper
    {
        DataContext DbContext { get; }
        IUserRepository Users { get; }
        void SaveChanges();
        Task<int> SaveChangesAsync();
    }
}
