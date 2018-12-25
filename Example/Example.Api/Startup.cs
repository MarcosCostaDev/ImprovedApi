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
        public Startup(IConfiguration configuration) : base(configuration)
        {
            AssembliesMidiatR.Add("Example.Domain");

#if !DEBUG
            SwaggerEnabled = false;
#endif
        }


        // This method gets called by the runtime. Use this method to add services to the container.
        public override void ConfigureServices(IServiceCollection services)
        {
            services.AddCors();
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            services
                .AddScoped<ExampleContext, ExampleContext>()
                .AddTransient<IAlbumRepository, AlbumRepository>()
                .AddTransient<IArtistRepository, ArtistRepository>();

            base.ConfigureServices(services);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public override void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }


            base.Configure(app, env);




        }
    }
}
