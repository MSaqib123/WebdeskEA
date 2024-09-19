using WebdeskEA.DataAccess;
using WebdeskEA.DataAccess.DbInitilizer;
using WebdeskEA.Domain.RepositoryDapper;
using WebdeskEA.Domain.RepositoryDapper.IRepository;
using WebdeskEA.Domain.Service;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Data;
using WebdeskEA.DataAccess.DapperFactory;
using WebdeskEA.Models.ExternalModel;
using WebdeskEA.Models.MappingModel;
using Microsoft.Extensions.Configuration;
using WebdeskEA.Core.Configuration;
using Microsoft.AspNetCore.Authorization;
using WebdeskEA.Utility.EnumUtality;
using System.Data.SqlClient;

namespace WebdeskEA.Core.Extension
{
    public static class ServiceRegistrationExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration configuration)
        {
            // Register DbContext
            services.AddDbContext<WebdeskEADBContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

            // Register IDbConnection with SqlConnection
            services.AddScoped<IDbConnection>(sp =>
            {
                var connectionString = configuration.GetConnectionString("DefaultConnection");
                return new SqlConnection(connectionString);
            });

            // Dapper Connection
            services.AddSingleton<IDapperDbConnectionFactory, DapperDbConnectionFactory>();

            // Identity
            services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<WebdeskEADBContext>()
                .AddDefaultTokenProviders();

            // Custom Claims Factory
            services.AddScoped<IUserClaimsPrincipalFactory<ApplicationUser>, CustomClaimsPrincipalFactory>();

            // Identity Path Configuration
            services.ConfigureApplicationCookie(option =>
            {
                option.LoginPath = "/Identity/Account/Login";
                option.AccessDeniedPath = "/Settings/Error/UnAuthorizedAccess";
                option.LogoutPath = "/Identity/Account/Logout";
                option.SlidingExpiration = true;
                option.Cookie.HttpOnly = true;
                option.ExpireTimeSpan = TimeSpan.FromMinutes(30);
            });

            services.AddDistributedMemoryCache();

            // Session Registration
            services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromMinutes(30);
                options.Cookie.HttpOnly = true;
                options.Cookie.IsEssential = true;
            });

            // Add CORS policy
            services.AddCors(options =>
            {
                options.AddPolicy("AllowAll",
                    policy =>
                    {
                        policy.AllowAnyOrigin()
                              .AllowAnyHeader()
                              .AllowAnyMethod();
                    });
            });

            // Services LifeTime
            services.AddTransient<IDbInitilizer, DbInitilizer>();
            services.AddAutoMapper(typeof(MappingProfile));
            services.AddScoped<IEnumService, EnumService>();
            services.AddScoped<WebdeskEA.Domain.RepositoryEntity.IRepository.IApplicationUserRepository, WebdeskEA.Domain.RepositoryEntity.ApplicationUserRepository>();
            services.AddScoped<IImageService, ImageService>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<ICompanyRepository, CompanyRepository>();
            services.AddScoped<ICompanyUserRepository, CompanyUserRepository>();
            services.AddScoped<ICompanyBusinessCategoryRepository, CompanyBusinessCategoryRepository>();
            services.AddScoped<ICOARepository, COARepository>();
            services.AddScoped<ICOATypeRepository, COATypeRepository>();
            services.AddScoped<IModuleRepository, ModuleRepository>();
            services.AddScoped<IUserRightsRepository, UserRightsRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IErrorLogRepository, ErrorLogRepository>();

            // TagHelper || RazorCompoennt
            services.AddHttpContextAccessor();
            services.AddAuthorizationCore();

            // Add Razor Pages
            services.AddRazorPages();

            // Permission Policies
            services.AddSingleton<IAuthorizationHandler, PermissionHandler>();
            services.AddScoped<PermissionDefinitions>();
            services.AddAuthorization();

            // Build ServiceProvider for custom configurator
            var serviceProvider = services.BuildServiceProvider();
            var configurator = new AuthorizationConfigurator(
                serviceProvider.GetRequiredService<IModuleRepository>(),
                serviceProvider.GetRequiredService<IUserRightsRepository>(),
                serviceProvider.GetRequiredService<PermissionDefinitions>()
            );
            configurator.ConfigurePolicies(services).GetAwaiter().GetResult();

            return services;
        }
    }
}
