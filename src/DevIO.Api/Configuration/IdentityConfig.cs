using DevIO.Api.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace DevIO.Api.Configuration
{
    public static class IdentityConfig
    {
        public static IServiceCollection AddIdentityConfiguration(
            this IServiceCollection services,
            IConfiguration configuration,
            ILoggerFactory MyLoggerFactory)
        {
            var conn = configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<ApplicationDbContext>(options =>
            {
                options
                    .UseSqlServer(conn)
                    .UseLoggerFactory(MyLoggerFactory)
                    .EnableSensitiveDataLogging();
            });

            return services;
        }
    }
}