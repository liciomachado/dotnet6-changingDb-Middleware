using Testes.changeDB.pg.Model;
using Testes.changeDB.pg.ViewModels;

namespace Testes.changeDB.pg.Repositories
{
    public interface IUserRepository
    {
        Task<Usuario> GetAsync(UserVM user);
    }
}
