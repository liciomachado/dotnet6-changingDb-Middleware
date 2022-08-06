using Microsoft.EntityFrameworkCore;

namespace Testes.changeDB.pg.Middleware
{
    public class SelectDatabaseMiddleware
    {
        private readonly RequestDelegate next;
        private PgDataContext _dbContext;
        private IConfiguration _configuration;


        public SelectDatabaseMiddleware(RequestDelegate next)
        {
            this.next = next;
        }

        public async Task Invoke(HttpContext context, PgDataContext dbContext, IConfiguration configuration)
        {
            _dbContext = dbContext;
            _configuration = configuration;

            string db = context.Request.Headers["db"];
            if (db is null)
                db = _configuration.GetConnectionString("defaultDB");

            var connectionString = _configuration.GetConnectionString("Testedb").Replace("{dbname}", db);
            _dbContext.Database.GetDbConnection().ConnectionString = connectionString;
            await next(context);
        }
    }
}
