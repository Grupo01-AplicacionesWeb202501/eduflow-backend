namespace EduflowBackend.Profiles.Domain.Model.ValueObjects;

public class UserType
{
    public string Value { get; }

    private static readonly HashSet<string> AllowedTypes = ["student", "teacher"];

    public UserType(string value)
    {
        if (!AllowedTypes.Contains(value.ToLower()))
            throw new ArgumentException("Invalid user type.");

        Value = value.ToLower();
    }

    public override string ToString() => Value;
}