using Microsoft.AspNetCore.Mvc;
using Testes.changeDB.pg.Services;

namespace Testes.changeDB.pg.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HomeController : ControllerBase
    {
        private readonly IServiceContext serviceContext;

        public HomeController(IServiceContext serviceContext)
        {
            this.serviceContext = serviceContext;
        }

        [HttpGet("{db}")]
        public async Task<IActionResult> Get(string db)
        {
            var resp = await serviceContext.Get(db);
            return Ok(resp);
        }
    }
}
