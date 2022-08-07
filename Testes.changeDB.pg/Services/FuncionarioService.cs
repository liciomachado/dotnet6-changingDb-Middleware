using Microsoft.EntityFrameworkCore;
using Testes.changeDB.pg.Model;

namespace Testes.changeDB.pg.Services
{
    public class FuncionarioService : IFuncionarioService
    {
        private readonly DynamicDataContext _context;

        public FuncionarioService(DynamicDataContext context)
        {
            _context = context;
        }

        public async Task<List<Funcionario>> Get()
        {
            return await _context.Funcionarios.ToListAsync();
        }
    }
}
