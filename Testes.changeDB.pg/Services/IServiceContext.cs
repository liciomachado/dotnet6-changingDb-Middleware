using Testes.changeDB.pg;

namespace Testes.changeDB.pg.Services
{
    public interface IServiceContext
    {
        Task<List<Funcionario>> Get(string db);
    }
}
