namespace ConsoleAppBackgroundServiceDI.Config
{
    public class OpcClientConfiguration
    {
        public Cfg Kepserver { get; set; }
        public Cfg OpcMachines { get; set; }
    }

    public class Cfg
    {
        public string Url { get; set; }
        public string Port { get; set; } = "26543";

    }
}
