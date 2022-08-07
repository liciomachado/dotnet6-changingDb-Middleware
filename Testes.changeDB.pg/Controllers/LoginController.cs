using Microsoft.AspNetCore.Mvc;
using Testes.changeDB.pg.Repositories;
using Testes.changeDB.pg.Services;
using Testes.changeDB.pg.ViewModels;

namespace Testes.changeDB.pg.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LoginController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        private readonly ITokenService _tokenService;

        public LoginController(IUserRepository userRepository, ITokenService tokenService)
        {
            _userRepository = userRepository;
            _tokenService = tokenService;
        }

        [HttpPost]
        public async Task<ActionResult<dynamic>> AuthenticateAsync(UserVM user)
        {
            var resp = await _userRepository.GetAsync(user);

            if (resp is null)
                return NotFound("Usuario não encontrado");

            var token = _tokenService.GenerateToken(resp);

            return new
            {
                user = resp,
                token,
            };
        }
    }
}
