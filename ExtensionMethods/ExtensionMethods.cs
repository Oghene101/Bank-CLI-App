using System.Text.RegularExpressions;

namespace ExtensionMethods;

public static class ExtensionMethods
{
    public static bool IsAValidName(this string courseTitle)
    {
        var pattern = @"^[A-Za-z- ]+$";
        Regex regex = new Regex(pattern);
        var isAWord = regex.IsMatch(courseTitle);
        if (!isAWord || courseTitle.Trim('-').Length is 0)
        {
            Console.WriteLine("Enter a valid input !");
            return false;
        }
        return true;
    }

    public static (bool, int) IsAValidNumber(this string text)
    {
        if (!int.TryParse(text, out var parsedNumber))
        {
            Console.WriteLine("Enter a valid number!");
            return (false, -1);
        }
        return (true, parsedNumber);
    }

}
