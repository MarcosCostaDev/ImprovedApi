using AutoMapper;
using ImprovedApi.Api.Midlewares;
using ImprovedApi.Api.Security.Token;
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
        public List<string> AssembliesMidiatR { get; protected set; } = new List<string>();
        public List<Profile> AutoMapperProfiles { get; protected set; } = new List<Profile>();

        protected bool SwaggerEnabled { get; set; } = true; 
        protected readonly IConfiguration Configuration;

        // This method gets called by the runtime. Use this method to add services to the container.
        public virtual void ConfigureServices(IServiceCollection services)
        {

            if(Configuration.GetSection("TokenConfiguration") != null)
            {
                services.AddOptions();
                services.Configure<TokenConfiguration>(options => Configuration.GetSection("TokenConfiguration").Bind(options));
                services.AddSingleton<SigningConfigurations, SigningConfigurations>();
            }
            else
            {
                ImprovedLogger.Write(@"if you wish use token/authentication, please add 'TokenConfiguration' Section in your appsettings.json with properties as follows:
                                      'SecretKey', 'Audience', 'Issuer', 'Seconds'");
            }
           


            services.AddSingleton<IImprovedUnitOfWork, ImprovedUnitOfWork>()
                .AddSingleton(Configuration);


            AddMediatR(services);
            AddAutoMapper(services);

            if(SwaggerEnabled)
            {
                AddSwagger(services);
            }
           
        }


        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public virtual void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {

            if (SwaggerEnabled)
            {
                UseSwagger(app);
            }
                
            app.UseMiddleware(typeof(ErrorHandlingMiddleware));
            
            app.UseMvc();
        }



        #region MediatR
        public virtual void AddMediatR(IServiceCollection services)
        {
            if(AssembliesMidiatR.Any())
            {
                services.AddMediatR(AssembliesMidiatR.Select(p => AppDomain.CurrentDomain.Load(p)));
            }
            else
            {
                ImprovedLogger.Write("Please, inform the 'AssembliesMidiatR' inside contructor Startup class!");
            }

           
        }
        #endregion

        #region AutoMapper
        public virtual void AddAutoMapper(IServiceCollection services)
        {
            if(AutoMapperProfiles.Any())
            {
                Mapper.Initialize(cfg =>
                {
                    AutoMapperProfiles.ForEach(p => cfg.AddProfile(p));                   
                });
            }
           
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
                    ImprovedLogger.Write($@"Please add {Path.Combine(AppContext.BaseDirectory, Assembly.GetExecutingAssembly().GetName().Name)}.xml in your project. \n
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
