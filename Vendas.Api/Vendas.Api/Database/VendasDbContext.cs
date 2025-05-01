using Microsoft.EntityFrameworkCore;
using Vendas.Api.Models.Enums;
using Vendas.Api.Models;

namespace Vendas.Api.Database
{
    public class VendasDbContext : DbContext
    {
        public DbSet<Adicional> adicionals { get; set; } = default!;
        public VendasDbContext(DbContextOptions<VendasDbContext> options) : base(options) { }
        
            

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

        }
    }
}
