using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Example.Domain.Repository;
using Example.Infra.Context;
using Example.Infra.Repository;
using ImprovedApi.Api;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Example.Api
{
    public class Startup : ImprovedStartup
    {
        public Startup(IConfiguration configuration, ILogger<Startup> logger, ILoggerFactory logFactory, IHostingEnvironment hostingEnvironment) : base(configuration, logger, logFactory, hostingEnvironment)
        {
            AssembliesMidiatR.Add("Example.Domain");
            AuthenticationEnabled = true;

#if !DEBUG
            SwaggerEnabled = false;
#endif
        }


        // This method gets called by the runtime. Use this method to add services to the container.
        public override void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc()
              .SetCompatibilityVersion(CompatibilityVersion.Version_2_1)
              .AddJsonOptions(options =>
              {
                  options.SerializerSettings.NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore;
                  options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
              });

            services.AddCors();


            services
                .AddScoped<ExampleContext, ExampleContext>()
                .AddTransient<IAlbumRepository, AlbumRepository>()
                .AddTransient<IArtistRepository, ArtistRepository>();

            base.ConfigureServices(services);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public override void Configure(IApplicationBuilder app)
        {
            if (HostingEnvironment.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }


            base.Configure(app);
        }
    }
}
