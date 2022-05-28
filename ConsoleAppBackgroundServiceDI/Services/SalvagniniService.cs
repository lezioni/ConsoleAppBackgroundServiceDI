using ConsoleAppBackgroundServiceDI.Config;

namespace ConsoleAppBackgroundServiceDI.Services
{
    public class SalvagniniService: ISalvagniniService
    {
        private readonly SalvagniniConfiguration _salvagniniConfiguration;
        private readonly GlobalConfiguration _globalConfiguration;


        public SalvagniniService(SalvagniniConfiguration salvagniniConfiguration, GlobalConfiguration globalConfiguration)
        {
            _salvagniniConfiguration = salvagniniConfiguration;
            _globalConfiguration = globalConfiguration;

            // Start file system watcher
        }

        public void FileSystemWatcherStart()
        {
            Console.WriteLine("Ricevuto nuovo file, Invio stato macchina letto da : " + _salvagniniConfiguration.Nodes[0] + " a " + _globalConfiguration.ServiceName);
        }
    }
}
