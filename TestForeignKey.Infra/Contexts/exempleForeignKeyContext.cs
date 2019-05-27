using ImprovedApi.Infra.Contexts;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;
using TestForeignKey.Domain.Entities;
using TestForeignKey.Infra.Mappings;

namespace TestForeignKey.Infra.Contexts
{
    public class ExempleForeignKeyContext : ImprovedDbContext
    {
        public DbSet<One> One { get; set; }
        public DbSet<Many> Many { get; set; }
        public ExempleForeignKeyContext(IHostingEnvironment env, IConfiguration Configuration) : base(env, Configuration)
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
                .ApplyConfiguration(new OneMapping())
                .ApplyConfiguration(new ManyMapping());

            base.OnModelCreating(modelBuilder);
        }
    }
}
