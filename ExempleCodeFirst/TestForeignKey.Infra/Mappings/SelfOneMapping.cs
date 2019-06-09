using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using TestCodeFirst.Domain.Entities;

namespace TestCodeFirst.Infra.Mappings
{
    public class SelfOneMapping : IEntityTypeConfiguration<SelfOne>
    {
        public void Configure(EntityTypeBuilder<SelfOne> builder)
        {
            builder.ToTable("SelfOne");
            builder.HasKey(p => p.SelfOneID);
            builder.HasOne(p => p.BaseSelfOne).WithOne().HasForeignKey<SelfOne>(p => p.BaseSelfOneID);
            builder.HasOne(p => p.Many).WithMany(p => p.SelfOne).HasForeignKey(p => p.ManyID);
        }
    }
}
