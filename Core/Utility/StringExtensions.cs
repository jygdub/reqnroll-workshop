namespace Core.Utility;

public static class StringExtensions
{
    public static decimal ParseEuroAmount(this string euroString)
    {
        // Remove the '€' symbol and whitespace from the string
        euroString = euroString.Replace("€", "").Trim();
        // Replace , with . for decimal parsing
        euroString = euroString.Replace(',', '.');

        if (decimal.TryParse(euroString, out var result))
        {
            return result;
        }

        throw new ArgumentException($"Invalid Euro string '{euroString}'.");
    }
}