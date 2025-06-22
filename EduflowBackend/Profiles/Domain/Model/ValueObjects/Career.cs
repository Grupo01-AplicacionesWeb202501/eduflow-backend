namespace EduflowBackend.Profiles.Domain.Model.ValueObjects;

public class Career
{
    public string Value { get; private set; } = null!; 

    public Career(string value)
    {
        if (string.IsNullOrWhiteSpace(value)) throw new ArgumentException("Career is required.");
        Value = value.Trim();
    }

    public Career()
    {
    } 
}