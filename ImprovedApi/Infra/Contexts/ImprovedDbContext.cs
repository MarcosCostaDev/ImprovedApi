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

        public bool IsDead { get; private set; } = false;
        protected IConfigurationRoot _configurationRoot { get; private set; }
        public ImprovedDbContext(IHostingEnvironment env)
        {
            string pathToContentRoot = Directory.GetCurrentDirectory();
            string json = Path.Combine(pathToContentRoot, "appsettings.json");

            if (!File.Exists(json))
            {
                string pathToExe = Process.GetCurrentProcess().MainModule.FileName;
                pathToContentRoot = Path.GetDirectoryName(pathToExe);
            }

            IConfigurationBuilder configurationBuilder = new ConfigurationBuilder()
                .SetBasePath(pathToContentRoot)
                .AddJsonFile($"appsettings.json")
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", true);

            _configurationRoot = configurationBuilder.Build();
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
