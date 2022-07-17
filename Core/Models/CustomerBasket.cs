namespace Core.Models
{
    public class CustomerBasket
    {
        // Need an empty constructor for redis.
        public CustomerBasket()
        {
        }

        public CustomerBasket(string id)
        {
            Id = Id;
        }

        public string Id { get; set; }
        public List<BasketItem> Items { get; set; } = new List<BasketItem>();
    }
}
