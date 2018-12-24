using Example.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Example.Infra.Mapping
{
    internal class AlbumMapping : IEntityTypeConfiguration<Album>
    {
        public void Configure(EntityTypeBuilder<Album> builder)
        {
            builder.HasKey(p => p.AlbumId);
            builder.Property(p => p.Title).HasMaxLength(120);

            builder.HasOne(p => p.Artist).WithMany(p => p.Albums).HasForeignKey(p => p.ArtistId);
        }
    }
}
