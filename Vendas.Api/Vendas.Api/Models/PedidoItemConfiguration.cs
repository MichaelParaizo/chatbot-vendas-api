using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Vendas.Api.Models
{
    public class PedidoItemConfiguration : IEntityTypeConfiguration<PedidoItem>
    {
        public void Configure(EntityTypeBuilder<PedidoItem> builder)
        {

            builder.ToTable("pedidoItem");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.PedidoId).IsRequired().HasColumnType("numeric").HasColumnName("pedidoId");
            builder.Property(x => x.ProdutoId).IsRequired().HasColumnType("numeric").HasColumnName("produtoId");
            builder.Property(x => x.TamanhoId).IsRequired().HasColumnType("numeric").HasColumnName("tamanhoId");
            builder.Property(x => x.Observacao).IsRequired().HasMaxLength(100).HasColumnName("observacao");
            builder.HasOne(x => x.Produto).WithMany().HasForeignKey(x => x.ProdutoId);
            builder.HasOne(x => x.Tamanho).WithMany().HasForeignKey(x => x.TamanhoId);
            builder.HasMany(x => x.Sabores).WithOne(x => x.PedidoItem).HasForeignKey(x => x.PedidoItemId);
            builder.HasMany(x => x.Adicionais).WithOne(x => x.PedidoItem).HasForeignKey(x => x.PedidoItemId);


        }
    }
}