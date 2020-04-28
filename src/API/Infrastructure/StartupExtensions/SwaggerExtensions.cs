namespace API.Infrastructure.StartupExtensions
{
    using Microsoft.AspNetCore.Builder;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.OpenApi.Models;

    public static class SwaggerExtensions
    {
        private const string VersionConfig = "swagger:version";
        private const string TitleConfig = "swagger:title";
        private const string EndpointConfig = "swagger:endpoint";

        public static IServiceCollection AddSwaggerConfiguration(this IServiceCollection services, IConfiguration config)
        {
            var version = config.GetValue<string>(VersionConfig);
            var title = config.GetValue<string>(TitleConfig);

            services
                .AddSwaggerGen(c => c.SwaggerDoc(version,
                new OpenApiInfo
                {
                    Title = title,
                    Version = version
                }));

            return services;
        }

        public static IApplicationBuilder UseSwaggerConfiguration(this IApplicationBuilder app, IConfiguration config)
        {
            var version = config.GetValue<string>(VersionConfig);
            var title = config.GetValue<string>(TitleConfig);
            var endPoint = config.GetValue<string>(EndpointConfig);

            app.UseSwagger();
            app.UseSwaggerUI(c => {
                c.DefaultModelExpandDepth(0);
                c.SwaggerEndpoint(endPoint, $"{title} {version}");
                c.DocExpansion(Swashbuckle.AspNetCore.SwaggerUI.DocExpansion.None);
            });

            return app;
        }
    }
}
