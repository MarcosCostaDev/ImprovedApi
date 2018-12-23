using AutoMapper;
using ImprovedApi.Api.Midlewares;
using ImprovedApi.Infra.Loggers;
using ImprovedApi.Infra.Transactions;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Swashbuckle.AspNetCore.Swagger;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;

namespace ImprovedApi.Api
{
    public abstract class ImprovedStartup
    {
        public ImprovedStartup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public IList<string> AssembliesMidiatR { get; private set; } = new List<string>();
        protected readonly IConfiguration Configuration;

        // This method gets called by the runtime. Use this method to add services to the container.
        public virtual void ConfigureServices(IServiceCollection services)
        {


            services.AddSingleton<IUnitOfWork, UnitOfWork>()
                .AddSingleton(Configuration);

            AddMediatR(services);
            AddAutoMapper(services);

#if DEBUG
            AddSwagger(services);
#endif
        }


        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public virtual void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {

#if DEBUG
            UseSwagger(app);
#endif

            app.UseMiddleware(typeof(ErrorHandlingMiddleware));
        }



        #region MediatR
        public virtual void AddMediatR(IServiceCollection services)
        {
            services.AddMediatR(AssembliesMidiatR.Select(p => AppDomain.CurrentDomain.Load(p)));
        }
        #endregion

        #region AutoMapper
        public virtual void AddAutoMapper(IServiceCollection services)
        {

        }
        #endregion


        #region Swagger
        public virtual void AddSwagger(IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                try
                {
                    c.SwaggerDoc("v1", new Info
                    {
                        Version = "v1",
                        Title = "Improved Api",
                        Description = "An Example how to improve your api",
                        TermsOfService = "None",
                        Contact = new Contact() { Name = "Improved API", Url = "https://github.com/marcoslcosta/ImprovedApi" }
                    });
                    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                    c.IncludeXmlComments(xmlPath);
                    c.CustomSchemaIds(x => x.FullName);
                    c.ResolveConflictingActions(apiDescriptions => apiDescriptions.First());
                }
                catch (Exception ex)
                {
                    Logger.Write($@"Please add {Assembly.GetExecutingAssembly().GetName().Name}.xml in your project. \n
                        Go to properties -> build -> select checkbox 'XML documentation file' ");

                }


            });
        }

        public virtual void UseSwagger(IApplicationBuilder app)
        {
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Improved Api");
            });
        }

        #endregion

    }
}
