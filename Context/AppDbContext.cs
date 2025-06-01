using Loja_do_Manuel.Models;
using Microsoft.EntityFrameworkCore;

namespace Loja_do_Manuel.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Pedido> Pedidos { get; set; }
        public DbSet<Produto> Produtos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Pedido>()
                .HasKey(p => p.PedidoId);

            modelBuilder.Entity<Produto>()
                .HasKey(p => p.ProdutoId);

            modelBuilder.Entity<Produto>().OwnsOne(p => p.Dimensoes);
        }
    }
}
