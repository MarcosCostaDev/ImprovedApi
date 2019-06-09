using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using TestCodeFirst.Domain.Entities;

namespace TestCodeFirst.Infra.Mappings
{
    public class ToOneMapping : IEntityTypeConfiguration<ToOne>
    {
        public void Configure(EntityTypeBuilder<ToOne> builder)
        {
            builder.ToTable("ToOne");
            builder.HasKey(p => p.ToOneID);

            builder.HasOne(p => p.Many).WithOne(p => p.ToOne).HasForeignKey<ToOne>(p => p.ManyID);
        }
    }
}
