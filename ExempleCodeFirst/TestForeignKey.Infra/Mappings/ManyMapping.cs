using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using TestCodeFirst.Domain.Entities;

namespace TestCodeFirst.Infra.Mappings
{
    public class ManyMapping : IEntityTypeConfiguration<Many>
    {
        public void Configure(EntityTypeBuilder<Many> builder)
        {
            builder.ToTable("Many");
            builder.HasKey(p => p.ManyID);

            builder.HasOne(p => p.One).WithMany(p => p.Many).HasForeignKey(p => p.OneID);

        }
    }
}
