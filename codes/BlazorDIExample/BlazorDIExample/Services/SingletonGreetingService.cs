namespace BlazorDIExample.Services
{
    public class SingletonGreetingService : IGreetingService
    {
        private readonly Guid _id = Guid.NewGuid();

        public string GetGreeting()
        {
            return $"Hello from Singleton Service! ID: {_id}";
        }
    }
}
