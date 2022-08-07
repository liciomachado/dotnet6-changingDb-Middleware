using Microsoft.EntityFrameworkCore;
using Testes.changeDB.pg.Services;

namespace Testes.changeDB.pg.Middleware
{
    public class SelectDatabaseMiddleware
    {
        private readonly RequestDelegate next;
        private DynamicDataContext _dbContext;
        private IConfiguration _configuration;
        private ITokenService _tokenService;

        public SelectDatabaseMiddleware(RequestDelegate next)
        {
            this.next = next;
        }

        public async Task Invoke(HttpContext context, DynamicDataContext dbContext, IConfiguration configuration, ITokenService tokenService)
        {
            _dbContext = dbContext;
            _configuration = configuration;
            _tokenService = tokenService;

            string db = _tokenService.GetDbFromToken();
            if (db is null)
                db = _configuration.GetConnectionString("defaultDB");

            var connectionString = _configuration.GetConnectionString("DynamicDB").Replace("{dbname}", db);
            _dbContext.Database.GetDbConnection().ConnectionString = connectionString;
            await next(context);
        }
    }
}
