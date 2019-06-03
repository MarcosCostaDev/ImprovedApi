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
    public abstract class ImprovedDbFirstContext : ImprovedBaseContext
    {
        public ImprovedDbFirstContext(IHostingEnvironment env, IConfiguration configuration)
        {
            _env = env;
            _configurationRoot = configuration;
        }
    }
}
