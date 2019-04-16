using Flunt.Notifications;
using ImprovedApi.Infra.Loggers.QueryLogger;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using System.IO;

namespace ImprovedApi.Infra.Contexts
{
    public abstract class ImprovedDbContext : DbContext
    {

        public bool IsDead { get; set; } = false;
        protected IConfiguration _configurationRoot { get; set; }
        protected IHostingEnvironment _env { get; set; }
        public ImprovedDbContext(IHostingEnvironment env, IConfiguration Configuration)
        {
            _env = env;
            _configurationRoot = Configuration;
        }
       
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var loggerFactory = new LoggerFactory();
            loggerFactory.AddProvider(new TraceLoggerProvider());
            optionsBuilder.UseLoggerFactory(loggerFactory);
            optionsBuilder.EnableSensitiveDataLogging();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Ignore<Notifiable>()
                .Ignore<Notification>();
             

            base.OnModelCreating(modelBuilder);
        }

        public override void Dispose()
        {
            IsDead = true;
            base.Dispose();
        }
    }
}
