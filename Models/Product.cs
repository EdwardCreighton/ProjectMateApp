namespace ProjectMateApp.Models
{
    internal class Product
    {
        public string Name { get; }
        public float Price { get; }
        public ProductType Type { get; }
        public DateTime SubscriptionExpirationDate { get; }
    }
}
