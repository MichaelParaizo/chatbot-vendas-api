using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Vendas.Api.Models
{
    public class ClienteConfiguration : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> builder)
        {

            builder.ToTable("cliente");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Nome).IsRequired().HasMaxLength(50).HasColumnName("nome");
            builder.Property(x => x.Endereco).IsRequired().HasMaxLength(100).HasColumnName("endereco");
            builder.Property(x => x.Telefone).IsRequired().HasColumnType("numeric").HasColumnName("telefone");


        }
    }
}
