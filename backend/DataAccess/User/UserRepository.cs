using Microsoft.EntityFrameworkCore;
using MOTOSTORE.Models;

namespace MOTOSTORE.DataAccess
{
    public interface IUserRepository : IRepositoryBase<User>
    {
        Task<User> GetByUsername(string email);
    }
    public class UserRepository: RepositoryBase<User>, IUserRepository
    {
        private new readonly DataContext RepositoryContext;
        private readonly IConfiguration Configuration;
        public UserRepository(DataContext repositoryContext, IConfiguration configuration): base(repositoryContext)
        {
            RepositoryContext = repositoryContext;
            Configuration = configuration;
        }
        public async Task<User> GetByUsername(string email)
        {
            return await RepositoryContext.Users.FirstOrDefaultAsync(x => x.Email == email);
        }
    }
}
