namespace EduflowBackend.Profiles.Domain.Model.ValueObjects;

public class Subject
{
    public string Value { get; private set; } 

    public Subject(string value)
    {
        if (string.IsNullOrWhiteSpace(value)) throw new ArgumentException("Subject is required.");
        Value = value.Trim();
    }

    protected Subject()
    {
        Value = string.Empty;
    } // For EF
}