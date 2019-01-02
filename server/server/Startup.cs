using System;
using System.IO;
using System.Reflection;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;
using Swashbuckle.AspNetCore.Swagger;
using Taskly.Infrastructure;

namespace Taskly
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            services.AddSwaggerGen(options =>
            {
                options
                    .SwaggerDoc("v1",
                        new Info
                        {
                            Version = "v1",
                            Title = "API",
                            Description = "Description",
                            TermsOfService = "None"
                        });

                var xmlDocsPath = Configuration.GetValue<string>("xml_docs");
                if (string.IsNullOrWhiteSpace(xmlDocsPath) == false)
                    options.IncludeXmlComments(xmlDocsPath);
                options.DescribeAllEnumsAsStrings();

                var basePath = AppContext.BaseDirectory;
                var xmlPath = Path.Combine(basePath, "server.xml");
                options.IncludeXmlComments(xmlPath);
            });

            services
                .Configure<IISOptions>(options =>
                {
                    options.ForwardClientCertificate = true;
                })
                .AddCors()
                .AddMvc()
                .AddJsonOptions(json =>
                {
                    json.SerializerSettings.NullValueHandling = NullValueHandling.Include;
                    json.SerializerSettings.DefaultValueHandling = DefaultValueHandling.Populate;
                    json.SerializerSettings.ContractResolver = new  CamelCasePropertyNamesContractResolver();
                    json.SerializerSettings.Formatting = Formatting.Indented;
                    json.SerializerSettings.Converters.Add(new StringEnumConverter());
                    json.SerializerSettings.DateTimeZoneHandling = DateTimeZoneHandling.Utc;
                    json.SerializerSettings.TypeNameHandling = TypeNameHandling.Auto;
                });

            var containerBuilder = new ContainerBuilder();
            containerBuilder.Populate(services);
            containerBuilder.RegisterAssemblyModules(typeof(ServicesInstaller).GetTypeInfo().Assembly);
            var container = containerBuilder.Build();

            return new AutofacServiceProvider(container);
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseBrowserLink();
            app.UseDeveloperExceptionPage();

            app.UseDefaultFiles();
            app.UseStaticFiles();
            app.UseStatusCodePages();
            app.UseSwagger()
                .UseSwaggerUI(options =>
                {
                    var sitename = Configuration.GetValue<string>("sitename");

                    var basePath = AppContext.BaseDirectory;
                    var webConfigPath = Path.Combine(basePath, "web.config");
                    options.SwaggerEndpoint(File.Exists(webConfigPath) ?
                        "/"+ sitename + "/swagger/v1/swagger.json"
                        : "/swagger/v1/swagger.json", 
                    "Values providing API v1");

                });
            app.UseMvc();
        }
    }
}
