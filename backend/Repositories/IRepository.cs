using Microsoft.EntityFrameworkCore;

using Motostore.DataAccess;
using Motostore.Models;

namespace Motostore.Repositories
{
    public interface IRepository
    {
        DataContext DbContext { get; }
        IUserRepository User { get; }
        int Save();
        Task<int> SaveAsync();
    }
}
