using System.Text.RegularExpressions;

namespace VerticalSlice.Models;
public sealed record Email(string email)
{
    public string Value => IsValid(email) ? email : throw new ApplicationException("Email is invalid !");
    private static bool IsValid(string value)
    {
        return Regex.IsMatch(
            value,
            @"^[^@\s]+@[^@\s]+\.[^@\s]+$",
            RegexOptions.IgnoreCase | RegexOptions.Compiled
        );
    }
}
