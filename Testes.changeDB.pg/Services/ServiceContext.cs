using Microsoft.EntityFrameworkCore;

namespace Testes.changeDB.pg.Services
{
    public class ServiceContext : IServiceContext
    {
        private readonly PgDataContext _context;

        public ServiceContext(PgDataContext context)
        {
            _context = context;
        }

        public async Task<List<Funcionario>> Get(string db)
        {
            return await _context.Funcionarios.ToListAsync();
        }
    }
}
