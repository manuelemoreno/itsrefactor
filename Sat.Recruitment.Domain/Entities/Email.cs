using System.Text.RegularExpressions;

namespace Sat.Recruitment.Domain.Entities;

public class Email
{
    private Email(string emailAddress)
    {
        EmailAddress = emailAddress;
    }

    public string EmailAddress { get; }

    public static Email Create(string email)
    {
        var normalizedEmail = NormalizeEmail(email);
        return new Email(normalizedEmail);
    }

    private static string NormalizeEmail(string email)
    {
        var emailSplit = email.Split(new[] {'@'}, StringSplitOptions.RemoveEmptyEntries);

        var formattedFirstPortion = Regex.Replace(emailSplit[0], @"[+.]+", "");

        return string.Join("@", formattedFirstPortion, emailSplit[1]);
    }
}