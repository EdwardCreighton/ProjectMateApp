namespace ProjectMateApp.Models
{
    public class Product
    {
        public string Name { get; }
        public int Price { get; }
        public ProductType Type { get; }
        public DateTime SubscriptionExpirationDate { get; }
    }
}
