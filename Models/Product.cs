namespace ProjectMateApp.Models
{
    public class Product
    {
        public string Name { get; }
        public int Price { get; }
        public ProductType Type { get; }
        public DateTime SubscriptionExpirationDate { get; }

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
                && ((Product)obj).Name == Name
                && ((Product)obj).Price == Price
                && ((Product)obj).Type == Type
                && ((Product)obj).SubscriptionExpirationDate == SubscriptionExpirationDate;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Name, Price, Type, SubscriptionExpirationDate);
        }
    }
}
