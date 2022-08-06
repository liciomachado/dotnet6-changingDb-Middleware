using Microsoft.EntityFrameworkCore;
using Testes.changeDB.pg;
using Testes.changeDB.pg.Middleware;
using Testes.changeDB.pg.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<PgDataContext>(
    o => o.UseNpgsql(builder.Configuration.GetConnectionString("Testedb"))
);
builder.Services.AddScoped<IServiceContext, ServiceContext>();
//builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
//builder.Services.AddDbContext<PgDataContext>((serviceProvider, dbContextBuilder) =>
//{
//    var connectionStringPlaceHolder = builder.Configuration.GetConnectionString("Testedb");
//    var httpContextAccessor = serviceProvider.GetRequiredService<IHttpContextAccessor>();
//    var dbName = httpContextAccessor.HttpContext.Request.Query["tenantId"].First();
//    var connectionString = connectionStringPlaceHolder.Replace("{dbname}", dbName);
//    dbContextBuilder.UseNpgsql(connectionString);
//});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();
app.UseMiddleware(typeof(SelectDatabaseMiddleware));
app.UseMiddleware(typeof(ErrorMiddleware));
app.MapControllers();

app.Run();
