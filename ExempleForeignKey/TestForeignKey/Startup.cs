using ImprovedApi.Api;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using TestCodeFirst.Domain.AutoMapper;
using TestCodeFirst.Domain.Repositories;
using TestCodeFirst.Infra.Contexts;
using TestCodeFirst.Infra.Repositories;

namespace TestCodeFirst
{
    public class Startup : ImprovedStartup
    {
        public Startup(IConfiguration configuration, ILogger<ImprovedStartup> logger, ILoggerFactory logFactory, IHostingEnvironment hostingEnvironment) : base(configuration, logger, logFactory, hostingEnvironment)
        {
            AssembliesMidiatR.Add("TestForeignKey.Domain");
            AutoMapperProfiles.Add(new MappingProfile());
            AuthenticationEnabled = false;

#if !DEBUG
            SwaggerEnabled = false;
#endif
        }


        // This method gets called by the runtime. Use this method to add services to the container.
        public override void ConfigureServices(IServiceCollection services)
        {

            services.AddCors();
            services
                .AddScoped<ExempleForeignKeyContext, ExempleForeignKeyContext>()
                .AddTransient<IOneRepository, OneRepository>()
                .AddTransient<IManyRepository, ManyRepository>()
                .AddTransient<IToOneRepository, ToOneRepository>()
                .AddTransient<ISelfOneRepository, SelfOneRepository>();

            base.ConfigureServices(services);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public override void Configure(IApplicationBuilder app)
        {
            if (HostingEnvironment.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors(x =>
            {
                x.AllowAnyHeader();
                x.AllowAnyMethod();
                x.AllowAnyOrigin();
            });


            base.Configure(app);
        }
    }
}
