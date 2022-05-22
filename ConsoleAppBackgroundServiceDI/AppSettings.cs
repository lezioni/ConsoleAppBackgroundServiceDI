using ConsoleAppBackgroundServiceDI.Config;

namespace ConsoleAppBackgroundServiceDI
{
    internal class AppSettings
    {
        public GlobalConfiguration GlobalConfiguration { get; set; }
        public OpcClientConfiguration OpcClientConfiguration { get; set; }
        public SalvagniniConfiguration SalvagniniConfiguration { get; set; }
        public MariaDbConfiguration MariaDbConfiguration { get; set; }
    }
}
