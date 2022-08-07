using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Testes.changeDB.pg;
using Testes.changeDB.pg.Middleware;
using Testes.changeDB.pg.Repositories;
using Testes.changeDB.pg.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<PgDataContext>(
    o => o.UseNpgsql(builder.Configuration.GetConnectionString("DefaultApplication"))
);
builder.Services.AddDbContext<DynamicDataContext>(
    o => o.UseNpgsql(builder.Configuration.GetConnectionString("DynamicDB"))
);
builder.Services.AddScoped<IFuncionarioService, FuncionarioService>();
builder.Services.AddScoped<ITokenService, TokenService>();


builder.Services.AddScoped<IUserRepository, UserRepository>();

var key = Encoding.ASCII.GetBytes(builder.Configuration["JwtSecret"]);
builder.Services.AddAuthentication(x =>
{
    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).
    AddJwtBearer(x =>
   {
       x.RequireHttpsMetadata = false;
       x.SaveToken = true;
       x.TokenValidationParameters = new TokenValidationParameters
       {
           ValidateIssuerSigningKey = true,
           IssuerSigningKey = new SymmetricSecurityKey(key),
           ValidateIssuer = false,
           ValidateAudience = false
       };
   });
builder.Services.AddHttpContextAccessor();
//builder.Services.AddDbContext<PgDataContext>((serviceProvider, dbContextBuilder) =>
//{
//    var connectionStringPlaceHolder = builder.Configuration.GetConnectionString("DynamicDB");
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

app.UseAuthentication();
app.UseAuthorization();
app.UseMiddleware(typeof(SelectDatabaseMiddleware));
app.UseMiddleware(typeof(ErrorMiddleware));
app.MapControllers();

app.Run();
