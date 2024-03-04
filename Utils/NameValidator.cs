using ProjectMateApp.Exceptions;
using System.Text.RegularExpressions;

namespace ProjectMateApp.Utils
{
    public static class NameValidator
    {
        private static readonly Regex NumbersRegex = new Regex("[0-9]+");

        public static void Validate(string name)
        {
            MatchCollection numbersMatches = NumbersRegex.Matches(name);

            if (numbersMatches.Count > 0)
                throw new NameContainsNumbersException();
        }

        public static string JoinName(string fn, string sn, string ln)
        {
            fn.Trim();
            sn.Trim();
            ln?.Trim();

            return $"{fn} {sn} {ln}";
        }

        public static void SeparateName(string name, out string fn, out string sn, out string ln)
        {
            string[] parts = name.Split(' ');
            fn = parts[0];
            sn = parts[1];
            ln = parts[2];
        }
    }
}
