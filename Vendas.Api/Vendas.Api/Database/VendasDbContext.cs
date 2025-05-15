using Microsoft.EntityFrameworkCore;
using Vendas.Api.Models.Enums;
using Vendas.Api.Models;
using System.Reflection;

namespace Vendas.Api.Database
{
    public class VendasDbContext : DbContext
    {
        public DbSet<Adicional> adicionals { get; set; } = default!;
        public DbSet<Sabor> sabors { get; set; } = default!;
        public DbSet<Cliente> clientes { get; set; } = default!;
        public DbSet<Pagamento> pagamentos { get; set; } = default!;
        public DbSet<Pedido> pedidos { get; set; } = default!;
        public DbSet<PedidoItem> pedidoItems { get; set; } = default!;
        public DbSet<PedidoItemAdicional> pedidoItemAdicionais { get; set; } = default!;
        public DbSet<PedidoItemSabor> pedidoItemSabores { get; set; } = default!;
        public DbSet<Produto> produtos { get; set; } = default!;
        public DbSet<Tamanho> tamanhos { get; set; } = default!;
        public VendasDbContext(DbContextOptions<VendasDbContext> options) : base(options) { }
        
            

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
           // modelBuilder.ApplyConfiguration(new AdicionalConfiguration());
           // modelBuilder.ApplyConfiguration(new ClienteConfiguration());
            base.OnModelCreating(modelBuilder);

        }
    }
}
