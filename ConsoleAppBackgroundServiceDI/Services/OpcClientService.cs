using ConsoleAppBackgroundServiceDI.Config;

namespace ConsoleAppBackgroundServiceDI.Services
{
    public class OpcClientService : IOpcClient
    {
        private readonly OpcClientConfiguration _opcClients;

        public OpcClientService(OpcClientConfiguration opcClients)
        {
            _opcClients = opcClients;
        }

        public string Connect(string machine)
        {
            string url = "";
            switch (machine)
            {
                case "Kepserver":
                    url = _opcClients.Kepserver.Url;
                    break;
                case "OpcMachines":
                    url = _opcClients.OpcMachines.Url;
                    break;
                default:
                    throw new Exception("Wrong machine name configuration value: " + machine);
            }
            Console.WriteLine(">>>> Connessione a OPC con url " + url);
            return (url);
        }

        public void read(string node)
        {
            Console.WriteLine("Leggo il nodo " +  node);
        }

        public void write(string node, string value)
        {
            Console.WriteLine("Scrivo il valore " + value + " sul nodo " + node);
        }
    }
}
