using ImprovedApi.Infra.Contexts;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;
using TestCodeFirst.Domain.Entities;
using TestCodeFirst.Infra.Mappings;

namespace TestCodeFirst.Infra.Contexts
{
    public class ExempleForeignKeyContext : ImprovedCodeFirstContext
    {
        public DbSet<One> One { get; set; }
        public DbSet<Many> Many { get; set; }
        public DbSet<ToOne> ToOne { get; set; }
        public DbSet<SelfOne> SelfOne { get; set; }
        public ExempleForeignKeyContext(IHostingEnvironment env) : base(env)
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
                .ApplyConfiguration(new ManyMapping())
                .ApplyConfiguration(new ToOneMapping())
                .ApplyConfiguration(new SelfOneMapping());

            base.OnModelCreating(modelBuilder);
        }
    }
}
