namespace StateManagementDemo.Services
{
    public class CartService
    {
        private readonly List<string> items = new();

        public IReadOnlyList<string> Items => items.AsReadOnly();

        public void AddItem(string item)
        {
            items.Add(item);
        }

        public void RemoveItem(string item)
        {
            items.Remove(item);
        }
    }
}
