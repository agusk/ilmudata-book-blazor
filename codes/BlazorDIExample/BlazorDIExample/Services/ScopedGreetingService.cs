namespace BlazorDIExample.Services
{
    public class ScopedGreetingService : IGreetingService
    {
        private readonly Guid _id = Guid.NewGuid();

        public string GetGreeting()
        {
            return $"Hello from Scoped Service! ID: {_id}";
        }
    }
}
