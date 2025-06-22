
namespace EduflowBackend.Profiles.Domain.Model.ValueObjects;

public class Subject
{
    public string Value { get; private set; } = null!;

    public Subject(string value)
    {
        if (string.IsNullOrWhiteSpace(value)) throw new ArgumentException("Subject is required.");
        Value = value.Trim();
    }

    public Subject()
    {
    } // For EF
}