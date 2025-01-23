namespace BlazorDIExample.Services
{
    public class GreetingService : IGreetingService
    {
        private readonly Guid _id = Guid.NewGuid();


        public string GetGreeting()
        {
            return $"Hello from Transient Service! ID: {_id}";
        }
    }
}
