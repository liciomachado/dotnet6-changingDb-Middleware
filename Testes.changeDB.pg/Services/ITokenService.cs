using Testes.changeDB.pg.Model;

namespace Testes.changeDB.pg.Services
{
    public interface ITokenService
    {
        string GenerateToken(Usuario user);
        string GetDbFromToken();
    }
}
