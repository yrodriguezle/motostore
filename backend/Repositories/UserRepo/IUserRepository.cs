using Motostore.Models;

namespace Motostore.Repositories
{
    public interface IUserRepository : IRepositoryBase<User>
    {
        Task<User?> GetByUsername(string username);
    }
}
