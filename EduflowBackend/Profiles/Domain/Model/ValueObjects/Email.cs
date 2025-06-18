namespace EduflowBackend.Profiles.Domain.Model.ValueObjects;

public class Email
{
    public string Address { get; }

    public Email(string address)
    {
        if (string.IsNullOrWhiteSpace(address))
            throw new ArgumentException("Email cannot be empty.");

        if (!IsValid(address))
            throw new ArgumentException("Invalid email format.");

        Address = address.Trim().ToLower();
    }

    private static bool IsValid(string email)
    {
        return System.Text.RegularExpressions.Regex.IsMatch(
            email,
            @"^[^@\s]+@[^@\s]+\.[^@\s]+$"
        );
    }

    public override string ToString() => Address;
}