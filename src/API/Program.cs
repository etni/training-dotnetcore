namespace API
{
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.Extensions.Hosting;
    using Microsoft.Extensions.Logging;

    public class Program
    {
        private const string LoggingSection = "logging";

        public static void Main(string[] args) 
            => CreateHostBuilder(args)
                .Build()
                .Run();

        public static IHostBuilder CreateHostBuilder(string[] args)
            => Host
                .CreateDefaultBuilder(args)
                
                .ConfigureLogging((context, logging) =>
                    logging
                        .ClearProviders()
                        .AddConfiguration(context.Configuration.GetSection(LoggingSection))
                        .AddDebug()
                        .AddConsole())

                .ConfigureWebHostDefaults(webBuilder 
                    => webBuilder.UseStartup<Startup>());
    }
}
