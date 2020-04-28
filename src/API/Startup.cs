namespace API
{
    using Infrastructure.StartupExtensions;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Hosting;

    public class Startup
    {
        public Startup(IConfiguration configuration) 
            => Configuration = configuration;

        public IConfiguration Configuration { get; }

 
        public void ConfigureServices(IServiceCollection services)
        {
            services 
                .AddSwaggerConfiguration(Configuration)
                .AddCors()
                .AddControllers();
        }

 
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app 
                .UseHttpsRedirection()
                .UseSwaggerConfiguration(Configuration)
                .UseCors(config
                        => config
                            .AllowAnyOrigin()
                            .AllowAnyMethod()
                            .AllowAnyHeader())
                .UseRouting()
                .UseAuthorization()
                .UseEndpoints(endpoints 
                    => endpoints.MapControllers());
        }
    }
}
