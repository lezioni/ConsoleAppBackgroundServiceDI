using ConsoleAppBackgroundServiceDI.Config;
using Microsoft.Extensions.Hosting;

namespace ConsoleAppBackgroundServiceDI.Services
{
    public class BackgroundServiceB : BackgroundService
    {
        private readonly IMiddleAgeMachines _middleAgeMachineService;
        public BackgroundServiceB(IMiddleAgeMachines middleAgeMachineservice)
        {
            _middleAgeMachineService = middleAgeMachineservice;
        }

        protected async override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            Console.WriteLine("Avvio servizio B in background");
            while (!stoppingToken.IsCancellationRequested)
            {
                _middleAgeMachineService.Check();

                await Task.Delay(2000, stoppingToken);
            }
        }
    }
}
