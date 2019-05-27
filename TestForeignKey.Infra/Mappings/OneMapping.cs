using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using TestForeignKey.Domain.Entities;

namespace TestForeignKey.Infra.Mappings
{
    public class OneMapping : IEntityTypeConfiguration<One>
    {
        public void Configure(EntityTypeBuilder<One> builder)
        {
            builder.ToTable("One");
            builder.HasKey(p => p.OneID);
        }
    }
}
