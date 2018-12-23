using Example.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Example.Infra.Mapping
{
    public class OrderDetailMapping : IEntityTypeConfiguration<OrderDetail>
    {
        public void Configure(EntityTypeBuilder<OrderDetail> builder)
        {
            builder.ToTable("Order Details");
            builder.HasKey(p => p.OrderID);
            builder.Property(p => p.UnitPrice).IsRequired();
            builder.Property(p => p.Quantity).IsRequired();
            builder.Property(p => p.Discount).IsRequired();
        }
    }
}
