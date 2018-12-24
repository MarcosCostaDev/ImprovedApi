using Example.Domain.Entities;
using Example.Infra.Mapping;
using ImprovedApi.Infra.Contexts;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Example.Infra.Context
{
    public class ExampleContext : ImprovedDbContext
    {
        public DbSet<Album> Album { get; set; }
        public DbSet<Artist> Artist { get; set; }

        public ExampleContext(IHostingEnvironment env) : base(env)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer(_configurationRoot["ConnectionStrings:DefaultConnection"]);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .ApplyConfiguration(new AlbumMapping())
                .ApplyConfiguration(new ArtistMapping());

            base.OnModelCreating(modelBuilder);
        }
    }
}
