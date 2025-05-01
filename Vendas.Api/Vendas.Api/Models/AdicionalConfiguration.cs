using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Vendas.Api.Models
{
    public class AdicionalConfiguration : IEntityTypeConfiguration<Adicional>
    {
        public void Configure(EntityTypeBuilder<Adicional> builder)
        {

            builder.ToTable("adicional");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Titulo).IsRequired().HasMaxLength(100).HasColumnName("titulo");
            builder.Property(x => x.Tipo).IsRequired().HasMaxLength(50).HasColumnName("tipo");
            builder.Property(x => x.Valor).IsRequired().HasColumnType("numeric").HasColumnName("valor");
          

        }
    }
}
