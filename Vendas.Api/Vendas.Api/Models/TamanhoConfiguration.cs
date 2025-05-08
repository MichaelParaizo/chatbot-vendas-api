using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Vendas.Api.Models
{
    public class TamanhoConfiguration : IEntityTypeConfiguration<Tamanho>
    {
        public void Configure(EntityTypeBuilder<Tamanho> builder)
        {

            builder.ToTable("tamanho");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Descricao).IsRequired().HasMaxLength(100).HasColumnName("descricao");
            builder.Property(x => x.ValorBase).IsRequired().HasColumnType("numeric").HasColumnName("valorBase");


        }
    }
}
