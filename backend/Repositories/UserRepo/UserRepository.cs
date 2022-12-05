using Microsoft.EntityFrameworkCore;
using Motostore.DataAccess;
using Motostore.Models;
using System.Data.SqlTypes;
using System.Linq.Expressions;

namespace Motostore.Repositories
{
    public class UserRepository : RepositoryBase<User>, IUserRepository
    {
        private new readonly DataContext _dataContext;
        public UserRepository(DataContext dataContext, IConfiguration configuration) : base(dataContext)
        {
            _dataContext = dataContext;
        }
        public async Task<User?> GetByUsername(string username)
        {
            return await _dataContext.Users.FirstOrDefaultAsync((x) => x.Email.Substring(0, username.Length) == username || x.Email == username);
        }
    }
}
