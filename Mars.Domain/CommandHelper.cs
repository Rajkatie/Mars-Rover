using System.Text.RegularExpressions;

namespace Mars.Domain
{
    public static class CommandHelper
    {
        public static bool IsValidCommandChar(this string chars)
        => new Regex("^[mrl]+$", RegexOptions.IgnoreCase).IsMatch(chars);

    }
}
