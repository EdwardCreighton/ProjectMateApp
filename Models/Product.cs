namespace ProjectMateApp.Models
{
    public class Product
    {
        public string Name { get; set; }
        public int Price { get; set; }
        public ProductType Type { get; set; }
        public DateTime SubscriptionExpirationDate { get; set; }

        public Product(string name, int price, ProductType type, DateTime subscriptionExpirationDate)
        {
            Name = name;
            Price = price;
            Type = type;
            SubscriptionExpirationDate = subscriptionExpirationDate;
        }

        public override bool Equals(object? obj)
        {
            return obj != null
                && obj is Product product
                && product.Name == Name
                && product.Price == Price
                && product.Type == Type
                && product.SubscriptionExpirationDate == SubscriptionExpirationDate;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Name, Price, Type, SubscriptionExpirationDate);
        }
    }
}
