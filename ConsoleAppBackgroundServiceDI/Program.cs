using ConsoleAppBackgroundServiceDI.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;

namespace ConsoleAppBackgroundServiceDI
{
    internal class Program
    {
        static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureServices((hostContext, services) =>
                {
                    // Configuro AppSettings 
                    services.Configure<AppSettings>(hostContext.Configuration);
                    services.AddSingleton(provider => provider.GetRequiredService<IOptions<AppSettings>>().Value);

                    // Registro le sue sezioni
                    services.AddSingleton(provider => provider.GetRequiredService<AppSettings>().GlobalConfiguration);
                    services.AddSingleton(provider => provider.GetRequiredService<AppSettings>().OpcClientConfiguration);
                    services.AddSingleton(provider => provider.GetRequiredService<AppSettings>().SalvagniniConfiguration);
                    services.AddSingleton(provider => provider.GetRequiredService<AppSettings>().MariaDbConfiguration);

                    // Validare la correttezza del file di configurazione
                    // https://andrewlock.net/adding-validation-to-strongly-typed-configuration-objects-in-asp-net-core/

                    services.AddSingleton<ISalvagniniService, SalvagniniService>();
                    services.AddSingleton<IMiddleAgeMachines, MariaDbService>();
                    services.AddSingleton<IOpcClient, OpcClientService>();

                    services.AddHostedService<BackgroundServiceA>();
                    services.AddHostedService<BackgroundServiceB>();
                });
    }
}