using Testes.changeDB.pg.Model;

namespace Testes.changeDB.pg.Services
{
    public interface IServiceContext
    {
        Task<List<Funcionario>> Get();
    }
}
