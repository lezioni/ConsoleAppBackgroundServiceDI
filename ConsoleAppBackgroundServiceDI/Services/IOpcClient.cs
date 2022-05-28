namespace ConsoleAppBackgroundServiceDI.Services
{
    public interface IOpcClient
    {
        public void write(string node, string value);
        public void read(string node);
        public string Connect(string machine);
    }
}
