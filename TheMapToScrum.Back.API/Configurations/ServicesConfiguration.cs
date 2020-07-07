using Microsoft.Extensions.DependencyInjection;

namespace TheMapToScrum.Back.Configurations
{
    public static class ServicesConfiguration
    {
        public static IServiceCollection AddCORS(this IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                    builder => builder.WithOrigins("http://example.com")
                        .AllowAnyMethod()
                        .AllowAnyHeader()
                        .AllowCredentials());
            });

            return services;
        }

       
    }
}
