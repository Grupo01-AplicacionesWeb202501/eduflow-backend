namespace EduflowBackend.Profiles.Domain.Model.ValueObjects;

public class FullName
{
    public string Value { get; }

    public FullName(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            throw new ArgumentException("Full name cannot be empty.");

        Value = value.Trim();
    }

    public override string ToString() => Value;
}