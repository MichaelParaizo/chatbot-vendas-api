using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Vendas.Api.Models
{
    public class PedidoConfiguration : IEntityTypeConfiguration<Pedido>
    {
        public void Configure(EntityTypeBuilder<Pedido> builder)
        {

            builder.ToTable("pedido");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.ClienteId).IsRequired().HasMaxLength(20).HasColumnName("clienteId");
            builder.Property(x => x.Observacao).IsRequired().HasMaxLength(100).HasColumnName("observacao");
            builder.Property(x => x.Total).IsRequired().HasColumnType("numeric").HasColumnName("total");
            builder.Property(x => x.PagamentoId).IsRequired().HasColumnType("numeric").HasColumnName("pagamentoId");
            builder.HasMany(x => x.Itens)
                .WithOne(x => x.Pedido)
                .HasForeignKey(x => x.PedidoId);
            builder.HasOne(x => x.Pagamento)
                .WithMany()
                .HasForeignKey(x => x.PagamentoId);
            builder.HasOne(x => x.Cliente)
                .WithMany()
                .HasForeignKey(x => x.ClienteId);

        }
    }
}
