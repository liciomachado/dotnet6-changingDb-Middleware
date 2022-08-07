using Microsoft.EntityFrameworkCore;
using Testes.changeDB.pg.Model;

namespace Testes.changeDB.pg
{
    public class DynamicDataContext : DbContext
    {
        public DynamicDataContext(DbContextOptions<DynamicDataContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseSerialColumns();
        }

        public DbSet<Funcionario> Funcionarios { get; set; }

    }
}
