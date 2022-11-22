using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using MOTOSTORE.Helpers;

namespace MOTOSTORE.DataAccess
{
    public interface IRepositoryBase<T> where T : class
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
    public class RepositoryWrapper : IRepositoryWrapper
    {
        public bool DbContextSingle = false;
        protected readonly IConfiguration Configuration;
        private readonly DataContext RepositoryContext;
        public RepositoryWrapper(IConfiguration configuration, DataContext dataContext)
        {
            Configuration = configuration;
            RepositoryContext = dataContext;
        }
        public DataContext DbContext
        {
            get { return RepositoryContext; }
        }
        private DataContext GetNewDbContext()
        {
            if (DbContextSingle)
            {
                return RepositoryContext;
            }
            return new DataContext(Configuration);
        }
        public void SaveChanges()
        {
            RepositoryContext.SaveChanges();
        }
        public async Task<int> SaveChangesAsync()
        {
            return await RepositoryContext.SaveChangesAsync();
        }
        public IUserRepository Users
        {
            get
            {
                return new UserRepository(GetNewDbContext(), Configuration);
            }
        }
    }
}
