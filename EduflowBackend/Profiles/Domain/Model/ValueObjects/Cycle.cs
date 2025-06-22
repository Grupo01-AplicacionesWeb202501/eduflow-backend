namespace EduflowBackend.Profiles.Domain.Model.ValueObjects;

public class Cycle
{
    public int Value { get; private set; } = 0;

    public Cycle(int value)
    {
        if (value < 1 || value > 10) throw new ArgumentException("Cycle must be between 1 and 10.");
        Value = value;
    }

    public Cycle()
    {
    } // For EF
}