using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Testes.changeDB.pg.Services;

namespace Testes.changeDB.pg.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HomeController : ControllerBase
    {
        private readonly IFuncionarioService serviceContext;

        public HomeController(IFuncionarioService serviceContext)
        {
            this.serviceContext = serviceContext;
        }

        [HttpGet, Authorize]
        public async Task<IActionResult> Get()
        {
            var resp = await serviceContext.Get();
            return Ok(resp);
        }
    }
}
