using ProjectMateApp.Exceptions;
using System.Text.RegularExpressions;

namespace ProjectMateApp.Utils
{
    public static class PriceValidator
    {
        private static readonly Regex CharactersRegex = new Regex("[a-zA-Zа-яА-Я]+");

        public static void Validate(string priceValue)
        {
            MatchCollection charactersMatches = CharactersRegex.Matches(priceValue);

            if (charactersMatches.Count > 0)
                throw new PriceContainsCharactersException();
        }
    }
}
