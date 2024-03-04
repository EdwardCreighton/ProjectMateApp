namespace ProjectMateApp.Models
{
    public class Manager
    {
        public string Name { get; }

        public Manager(string name)
        {
            Name = name;
        }

        public override bool Equals(object? obj)
        {
            return obj != null
                && obj is Manager manager
                && manager.Name == Name;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Name);
        }
    }
}
