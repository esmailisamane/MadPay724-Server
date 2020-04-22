using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using AutoMapper;
using MadPay724.Common.Helpers;
using MadPay724.Common.Helpers.Helpers;
using MadPay724.Common.Helpers.Interface;
using MadPay724.Data.DatabaseContext;
using MadPay724.Presentation.Helpers.Filters;
using MadPay724.Repo.Infrastructure;
using MadPay724.Services.Seed.Interface;
using MadPay724.Services.Seed.Service;
using MadPay724.Services.Site.Admin.Auth.Interface;
using MadPay724.Services.Site.Admin.Auth.Service;
using MadPay724.Services.Upload.Interface;
using MadPay724.Services.Upload.Service;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using NSwag.Generation.Processors.Security;

namespace MadPay724.Presentation
{
    public class Startup
    {
        private readonly int? _httpsPort;
        public Startup(IConfiguration configuration, IWebHostEnvironment env)
        {
            Configuration = configuration;
            if (env.IsDevelopment())
            {
                var lunchJsonConf = new ConfigurationBuilder()
                    .SetBasePath(env.ContentRootPath)
                    .AddJsonFile("Properties\\launchSettings.json")
                    .Build();

                _httpsPort = lunchJsonConf.GetValue<int>("iisSettings:iisExpress:sslPort");
            }
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
           
                 services.AddMvc(config =>
                 {
                     config.EnableEndpointRouting = false;
                     config.ReturnHttpNotAcceptable = true;
                     config.SslPort = _httpsPort;
                     config.Filters.Add(typeof(RequireHttpsAttribute));
                     config.Filters.Add(typeof(LinkRewritingFilter));

                 //var jsonFormatter = config.OutputFormatters.OfType<JsonOutputFormatter>().Single();
                 //config.OutputFormatters.Remove(jsonFormatter);
                 //config.OutputFormatters.Add(new IonOutputFormatter(jsonFormatter));
                 //config.OutputFormatters.Add(new XmlDataContractSerializerOutputFormatter());
                 //config.InputFormatters.Add(new XmlSerializerInputFormatter(config));
               
                 })

                 .AddNewtonsoftJson(opt =>
                 {
                     opt.SerializerSettings.ReferenceLoopHandling =
                     Newtonsoft.Json.ReferenceLoopHandling.Ignore;
                 });

            services.AddResponseCaching();

            services.AddHsts(opt =>
                {
                    opt.MaxAge = TimeSpan.FromDays(180);
                    opt.IncludeSubDomains = true;
                    opt.Preload = true;

                });

            //services.AddRouting(opt => opt.LowercaseUrls = true);

            // برای ورژنینگ استفاده  میشه
            //services.AddRouting( opt => opt.LowercaseUrls = true);
            //services.AddApiVersioning(opt =>
            //{
            //    opt.ApiVersionReader = new MediaTypeApiVersionReader();
            //    opt.AssumeDefaultVersionWhenUnspecified = true;
            //    opt.ReportApiVersions = true;
            //    opt.DefaultApiVersion = new ApiVersion(1,0);
            //    opt.ApiVersionSelector = new CurrentImplementationApiVersionSelector(opt);
            //});

            services.AddCors();

           // services.Configure<CloudinarySettings>(Configuration.GetSection("CloudinarySettings"));

            services.AddAutoMapper(typeof(Startup));
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            services.AddScoped<IUnitOfWork<MadpayDbContext>, UnitOfWork<MadpayDbContext>>();
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IUploadService, UploadService>();
            services.AddScoped<IUtilities, Utilities>();
            services.AddScoped<UserCkeckIdFilter>();


            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(opt =>
                {
                    opt.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(Configuration.GetSection("AppSettings:Token").Value)),
                        ValidateIssuer = false,
                        ValidateAudience = false
                    };
                });
            //Swagger
            services.AddOpenApiDocument(document =>
            {
                document.DocumentName = "v1_Site_Admin";
                document.ApiGroupNames = new[] { "v1_Site_Admin" };
                document.PostProcess = d =>
                {
                    d.Info.Title = "NanoBeton";
                    //d.Info.Contact = new NSwag.OpenApiContact
                    //{
                    //    Name = "Samane",
                    //    Email = string.Empty,
                    //    Url = "",
                    //};
                    //d.Info.License = new NSwag.OpenApiLicense
                    //{
                    //    Name = "",
                    //    Url = "",

                    //};
                };

                document.AddSecurity("JWT", Enumerable.Empty<string>(), new NSwag.OpenApiSecurityScheme
                {
                    Type = NSwag.OpenApiSecuritySchemeType.ApiKey,
                    Name = "Authorization",
                    In = NSwag.OpenApiSecurityApiKeyLocation.Header,
                    Description = "Tset",
                });

                document.OperationProcessors.Add(
                    new AspNetCoreOperationSecurityScopeProcessor("JWT"));

            });

            services.AddOpenApiDocument(document =>
            {
                document.DocumentName = "Api";
                document.ApiGroupNames = new[] { "Api" };
                document.PostProcess = d =>
                {
                    d.Info.Title = "Api Controller";
                    
                };
                document.AddSecurity("JWT", Enumerable.Empty<string>(), new NSwag.OpenApiSecurityScheme
                {
                    Type = NSwag.OpenApiSecuritySchemeType.ApiKey,
                    Name = "Authorization",
                    In = NSwag.OpenApiSecurityApiKeyLocation.Header,
                    Description = "Tset",
                });

                document.OperationProcessors.Add(
                    new AspNetCoreOperationSecurityScopeProcessor("JWT"));
            });
            //

            services.AddTransient<ISeedService, SeedService>();
            
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ISeedService seeder)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler(builder =>
                {
                    builder.Run(async context =>
                    {
                        context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                        var error = context.Features.Get<IExceptionHandlerFeature>();
                        if (error != null)
                        {
                            context.Response.AddAppError(error.Error.Message);
                            await context.Response.WriteAsync(error.Error.Message);
                        }
                    });
                });
               
            }
            app.UseHsts();
            //seeder.SeedUsers();
            app.UseHttpsRedirection();
            app.UseResponseCaching();
            app.UseCors(p => p.WithOrigins("http://localhost:4200").AllowAnyMethod().AllowAnyHeader().AllowCredentials());
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
           
            // swagger
            app.UseOpenApi();
            app.UseSwaggerUi3();

            //

            //app.UseEndpoints(endpoints =>
            //{
            //    endpoints.MapControllers();
            //});
            app.UseStaticFiles(new StaticFileOptions()
            {
               // FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot")),
                RequestPath = new PathString("/wwwroot")
            });
            app.UseMvc();
        }
    }
}
