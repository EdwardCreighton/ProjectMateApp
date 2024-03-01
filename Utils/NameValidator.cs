using ProjectMateApp.Exceptions;
using System.Text.RegularExpressions;

namespace ProjectMateApp.Utils
{
    public static class NameValidator
    {
        private static readonly Regex NumbersRegex = new Regex("[0-9.-]+");

        public static void Validate(string name)
        {
            MatchCollection matches = NumbersRegex.Matches(name);

            if (matches.Count > 0)
                throw new NameContainsNumbersException();
        }
    }
}
