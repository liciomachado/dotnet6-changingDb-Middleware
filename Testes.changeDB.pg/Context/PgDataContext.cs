using Microsoft.EntityFrameworkCore;

namespace Testes.changeDB.pg
{
    public class PgDataContext : DbContext
    {
        public PgDataContext(DbContextOptions<PgDataContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseSerialColumns();
        }

        public DbSet<Funcionario> Funcionarios { get; set; }

    }
}
