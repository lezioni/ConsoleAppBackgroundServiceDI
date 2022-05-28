using ConsoleAppBackgroundServiceDI.Config;
using Microsoft.Extensions.Hosting;

namespace ConsoleAppBackgroundServiceDI.Services
{
    public class BackgroundServiceB : BackgroundService
    {
        private readonly IMiddleAgeMachines _middleAgeMachineService;
        private readonly IOpcClient _opcClient;
        private string KepSession;
        private string MiddleAgeSession;

        public BackgroundServiceB(IMiddleAgeMachines middleAgeMachineservice, IOpcClient opcClient)
        {
            _middleAgeMachineService = middleAgeMachineservice;
            _opcClient = opcClient;
            
            KepSession = _opcClient.Connect("Kepserver"); // da migliorare per non usare una stringa
            MiddleAgeSession = _opcClient.Connect("OpcMachines"); // da migliorare per non usare una stringa
            Console.WriteLine("++++++++++++++++++++++++++++++++++++++++++++++++");
        }

        protected async override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            Console.WriteLine("Avvio servizio B in background");
            while (!stoppingToken.IsCancellationRequested)
            {
                Console.WriteLine("--- Leggo il valore da MiddleAgeMachines usando " + MiddleAgeSession);
                Console.WriteLine("--- Scrivo il valore su Kepware usando " + KepSession);
                await Task.Delay(2000, stoppingToken);
            }
        }
    }
}
