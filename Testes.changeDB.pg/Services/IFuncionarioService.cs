using Testes.changeDB.pg.Model;

namespace Testes.changeDB.pg.Services
{
    public interface IFuncionarioService
    {
        Task<List<Funcionario>> Get();
    }
}
