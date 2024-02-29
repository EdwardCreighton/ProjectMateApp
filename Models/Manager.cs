
namespace ProjectMateApp.Models
{
    public class Manager
    {
        public string Name { get; }

        public Manager(string name)
        {
            Name = name;
        }

        public static string JoinName(string fn, string sn, string ln)
        {
            return fn + " " + sn + " " + ln;
        }

        public static void SeparateName(string name, out string fn, out string sn, out string ln)
        {
            string[] parts = name.Split(' ');
            fn = parts[0];
            sn = parts[1];
            ln = parts[2];
        }

        public override bool Equals(object? obj)
        {
            return obj != null && Name == ((Manager)obj).Name;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Name);
        }
    }
}
