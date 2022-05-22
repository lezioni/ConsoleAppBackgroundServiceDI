namespace ConsoleAppBackgroundServiceDI.Services
{
    public class MariaDbService : IMiddleAgeMachines
    {
        public void Check()
        {
            Console.WriteLine("Interrogo il db MariaDb per verificare stato macchina");
        }
    }
}
