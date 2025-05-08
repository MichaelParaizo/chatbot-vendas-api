using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Vendas.Api.Models
{
    public class PedidoItemSaborConfiguration : IEntityTypeConfiguration<PedidoItemSabor>
    {
        public void Configure(EntityTypeBuilder<PedidoItemSabor> builder)
        {

            builder.ToTable("pedidoItemSabor");
            builder.HasKey(x => x.Id);
            builder.HasOne(x=> x.Sabor).WithMany().HasForeignKey(x=> x.SaborId);
    


        }
    }
}
