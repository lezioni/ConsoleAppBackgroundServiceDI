using ConsoleAppBackgroundServiceDI.Config;
using Microsoft.Extensions.Hosting;

namespace ConsoleAppBackgroundServiceDI.Services
{
    public class BackgroundServiceA : BackgroundService
    {
        private readonly GlobalConfiguration _globalConfiguration;
        private readonly ISalvagniniService _salvagniniService;
        public BackgroundServiceA(GlobalConfiguration adminConfiguration, ISalvagniniService servizioDiEsempio)
        {
            _globalConfiguration = adminConfiguration;
            _salvagniniService = servizioDiEsempio;
        }

        protected override async Task<Task> ExecuteAsync(CancellationToken stoppingToken)
        {
            Console.WriteLine("Avvio servizio A in background");
            while (!stoppingToken.IsCancellationRequested)
            {
                _salvagniniService.Stampa();
                // await Task.Delay(1000).Wait();
                await Task.Delay(5000);
            }
            Console.WriteLine("Task finito");
            return Task.CompletedTask;
        }
    }
}
