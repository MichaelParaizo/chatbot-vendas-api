﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Vendas.Api.Models

{
    public class PedidoItemAdicionalConfiguration : IEntityTypeConfiguration<PedidoItemAdicional>
    {
        public void Configure(EntityTypeBuilder<PedidoItemAdicional> builder)
        {

            builder.ToTable("pedidoItemAdicional");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.PedidoItemId).IsRequired().HasColumnName("pedidoItemId");
            builder.Property(x => x.AdicionalId).IsRequired().HasColumnName("adicionalId");
            builder.HasOne(x => x.Adicional).WithMany().HasForeignKey(x => x.AdicionalId);
    
        }
    }
}
