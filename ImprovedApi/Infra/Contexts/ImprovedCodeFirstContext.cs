using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;

namespace ImprovedApi.Infra.Contexts
{
    public class ImprovedCodeFirstContext : ImprovedBaseContext
    {
        public ImprovedCodeFirstContext(IHostingEnvironment env)
        {
            _env = env;
            OnSetConfiguration();
        }


        public virtual void OnSetConfiguration()
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
                .AddJsonFile($"appsettings.{_env.EnvironmentName}.json", true);

            _configurationRoot = configurationBuilder.Build();
        }
    }
}
