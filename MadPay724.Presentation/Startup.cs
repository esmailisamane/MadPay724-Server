using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using AutoMapper;
using MadPay724.Common.Helpers;
using MadPay724.Common.Helpers.AppSetting;
using MadPay724.Common.Helpers.Helpers;
using MadPay724.Common.Helpers.Interface;
using MadPay724.Data.DatabaseContext;
using MadPay724.Data.Models;
using MadPay724.Presentation.Helpers.Filters;
using MadPay724.Repo.Infrastructure;
using MadPay724.Services.Seed.Interface;
using MadPay724.Services.Seed.Service;
using MadPay724.Services.Site.Admin.Auth.Interface;
using MadPay724.Services.Site.Admin.Auth.Service;
using MadPay724.Services.Upload.Interface;
using MadPay724.Services.Upload.Service;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.AspNetCore.Rewrite;
using Microsoft.EntityFrameworkCore;
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
            services.AddDbContext<MadpayDbContext>(p => p.UseSqlServer(
            @"Data Source=DESKTOP-HO9R1KR\SA ;Initial Catalog = MadPay724db; Integrated Security= True; MultipleActiveResultSets=True"));
           // @"Data Source=WEB ;Initial Catalog = MadPay724db; Integrated Security= True; MultipleActiveResultSets=True"));

            services.AddDbContext<BPMS_NanobotonContext>(p => p.UseSqlServer(
            @"Data Source=DESKTOP-HO9R1KR\SA ;Initial Catalog =BPMS_Nanoboton; Integrated Security= True; MultipleActiveResultSets=True"));
          //@"Data Source=WEB ;Initial Catalog =BPMS_Nanoboton;Integrated Security= True;Integrated Security= True;"));

            services.AddMvc(config =>
                 {
                     config.EnableEndpointRouting = false;
                     config.ReturnHttpNotAcceptable = true;
                     config.SslPort = _httpsPort;
                     config.Filters.Add(typeof(RequireHttpsAttribute));
                    // config.Filters.Add(typeof(LinkRewritingFilter));
                     var policy = new AuthorizationPolicyBuilder()
                     .RequireAuthenticatedUser()
                     .Build();
                     config.Filters.Add(new AuthorizeFilter(policy));

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

           

          
            //services.AddAuthentication("Bearer")
            //    .AddIdentityServerAuthentication(opt =>
            //    {
            //        opt.Authority = "http://localhost:5000";
            //        opt.RequireHttpsMetadata = false;
            //        opt.ApiName = "MadPay724Api";
            //    });

            services.AddResponseCaching();

            services.AddHsts(opt =>
                {
                    opt.MaxAge = TimeSpan.FromDays(180);
                    opt.IncludeSubDomains = true;
                    opt.Preload = true;

                });
            services.AddHttpsRedirection(opt =>
            {
                opt.RedirectStatusCode = StatusCodes.Status302Found;

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

            //درحالت پابلیش کامنت شود
             services.AddCors();



            services.AddAutoMapper(typeof(Startup));
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            services.AddScoped<IUnitOfWork<MadpayDbContext>, UnitOfWork<MadpayDbContext>>();
          

            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IUploadService, UploadService>();
            services.AddScoped<IUtilities, Utilities>();
            services.AddScoped<UserCkeckIdFilter>();
            //services.AddScoped<TokenSetting>();



            IdentityBuilder builder = services.AddIdentityCore<User>(opt =>
            {
                opt.Password.RequireDigit = false;
                opt.Password.RequiredLength = 4;
                opt.Password.RequireNonAlphanumeric = false;
                opt.Password.RequireUppercase = false;
            });
            builder = new IdentityBuilder(builder.UserType, typeof(Role), builder.Services);
            builder.AddEntityFrameworkStores<MadpayDbContext>();
            builder.AddRoleValidator<RoleValidator<Role>>();
            builder.AddRoleManager<RoleManager<Role>>();
            builder.AddSignInManager<SignInManager<User>>();
            builder.AddDefaultTokenProviders();


           // services.Configure<TokenSetting>(Configuration.GetSection("TokenSetting"));

            var tokenSettingSection = Configuration.GetSection("TokenSetting");
            var tokenSetting = tokenSettingSection.Get<TokenSetting>();
            var key = Encoding.ASCII.GetBytes(tokenSetting.Secret);

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                    .AddJwtBearer(opt =>
                    {
                        opt.TokenValidationParameters = new TokenValidationParameters
                        {
                            ValidateIssuerSigningKey = true,
                            IssuerSigningKey = new SymmetricSecurityKey(key),
                            ValidateIssuer = true,
                            ValidIssuer = tokenSetting.Site,
                            ValidateAudience = true,
                            ValidAudience = tokenSetting.Audience,
                            ClockSkew = TimeSpan.Zero
                        };
                    });


            //Swagger
            services.AddOpenApiDocument(document =>
            {
                document.DocumentName = "v1_Site_Panel";
                document.ApiGroupNames = new[] { "v1_Site_Panel" };
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

            services.AddTransient<SeedService>();

            services.AddAuthorization(opt =>
            {
                opt.AddPolicy("RequireAdminRole", policy => policy.RequireRole("Admin"));

                opt.AddPolicy("AccessBlog", policy => policy.RequireRole("Admin", "Blog"));
                opt.AddPolicy("AccessAccounting", policy => policy.RequireRole("Admin", "Accountant"));
                opt.AddPolicy("AccessSeller", policy => policy.RequireRole("Admin", "Seller"));

                opt.AddPolicy("AccessProfile", policy => policy.RequireRole("Admin", "User", "Blog", "Accountant", "Seller"));

                opt.AddPolicy("RequireUserRole", policy => policy.RequireRole("User"));
                opt.AddPolicy("RequireBlogsRole", policy => policy.RequireRole("Blog"));
                opt.AddPolicy("RequireAccountantRole", policy => policy.RequireRole("Accountant"));
                opt.AddPolicy("RequireSellerRole", policy => policy.RequireRole("Seller"));
            });
            #region Publish
            //services.AddCors(opt =>
            //{
            //    opt.AddPolicy("CorsPolicy", builder =>
            //    builder.WithOrigins("http://localhost:4200", "http://127.0.0.1:8080", "https://Web.nanobetonamin.com")
            //            .AllowAnyMethod()
            //            .AllowAnyHeader()
            //            .AllowCredentials());
            //});

            //services.AddSpaStaticFiles(conf =>
            //{
            //    conf.RootPath = "Clients";
            //});
            #endregion

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, SeedService seeder)
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
           // seeder.SeedUsers();
            app.UseHttpsRedirection();
            app.UseResponseCaching();

            //هنگام پابلیش کامنت شود
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
            //app.UseStaticFiles(new StaticFileOptions()
            //{
            //   // FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot")),
            //    RequestPath = new PathString("/wwwroot")
            //});
            app.UseMvc();
            #region Publish

            /////////////////کلا این قسمت کامنته
            // // app.UseCsp(opt => opt.DefaultSources(s => s.Self()));
            ////app.UseXfo(o => o.Deny());
            ///////////////////////

            //app.UseCors("CorsPolicy");

            //app.UseDefaultFiles();
            //app.UseSpaStaticFiles();


            //app.UseRewriter(new RewriteOptions().AddRewrite(@"^\s*$", "/app", skipRemainingRules: true));

            //app.Map("/app", site =>
            //{
            //    site.UseSpa(spa =>
            //    {
            //        spa.Options.SourcePath = "Clients/app";
            //        spa.Options.DefaultPageStaticFileOptions = new StaticFileOptions
            //        {
            //            FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), "Clients/app"))
            //        };

            //    });

            //}).Map("/my", panel =>
            //{
            //    panel.UseSpa(spa =>
            //    {
            //        spa.Options.SourcePath = "Clients/my";
            //        spa.Options.DefaultPageStaticFileOptions = new StaticFileOptions
            //        {
            //            FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), "Clients/my"))
            //        };
            //    });
            //});

            #endregion
        }
    }
}
