using System.Text.RegularExpressions;

namespace EduflowBackend.Profiles.Domain.Model.ValueObjects;

public class Email
{
    private static readonly Regex EmailRegex = new(@"^[^@\s]+@[^@\s]+\.[^@\s]+$", RegexOptions.Compiled);

    public string Value { get; private set; }

    protected Email()
    {
        Value = string.Empty;
    } // For EF
    public Email(string value)
    {
        if (string.IsNullOrWhiteSpace(value)) throw new ArgumentException("Email is required.");
        if (!EmailRegex.IsMatch(value)) throw new ArgumentException("Invalid email format.");

        Value = value.Trim().ToLower();
    }

    
}