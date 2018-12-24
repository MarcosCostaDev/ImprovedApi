using Example.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Example.Infra.Mapping
{
    internal class ArtistMapping : IEntityTypeConfiguration<Artist>
    {
        public void Configure(EntityTypeBuilder<Artist> builder)
        {
            builder.HasKey(p => p.ArtistId);
            builder.Property(p => p.Name).HasMaxLength(120);
        }
    }
}
