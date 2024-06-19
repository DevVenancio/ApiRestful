using ApiRestful.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiRestful.Infra
{
    public class ConnectionContext : DbContext
    {
        public DbSet<Produto> Produtos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseNpgsql(
                "Server=localhost;" +
                "Port=5432;Database=ApiVize;" +
                "User Id=postgres; Password=1234;"
                );


    }
}
