using Microsoft.EntityFrameworkCore;
using Testes.changeDB.pg.Model;
using Testes.changeDB.pg.ViewModels;

namespace Testes.changeDB.pg.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly PgDataContext _pgDataContext;

        public UserRepository(PgDataContext pgDataContext)
        {
            _pgDataContext = pgDataContext;
        }

        public async Task<Usuario> GetAsync(UserVM user) => await _pgDataContext.Usuarios.FirstOrDefaultAsync(x => x.Username == user.Name);
    }
}
