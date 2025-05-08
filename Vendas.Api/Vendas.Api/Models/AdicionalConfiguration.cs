using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Vendas.Api.Models.Enums;

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
            builder.HasData(new Adicional { Id = 1, Titulo = "Borda", Tipo = "Borda Catupiry", Valor = 2 },
                new Adicional { Id = 2, Titulo = "Borda", Tipo = "Borda Cream Cheese", Valor = 2 },
                new Adicional { Id = 3, Titulo = "Borda", Tipo = "Borda Cheedar", Valor = 2 });



        }
    }
}
