using System;

namespace Sat.Recruitment.Api.Domain;

public class Email
{
    public Email(string emailAddress)
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
        var aux = email.Split(new[] {'@'}, StringSplitOptions.RemoveEmptyEntries);

        var atIndex = aux[0].IndexOf("+", StringComparison.Ordinal);

        aux[0] = atIndex < 0 ? aux[0].Replace(".", "") : aux[0].Replace(".", "").Remove(atIndex);

        return string.Join("@", aux[0], aux[1]);
    }
}