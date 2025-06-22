namespace EduflowBackend.Profiles.Domain.Model.ValueObjects;

public class FullName
{
    public string FirstName { get; private set; } = null!;
    public string LastName { get; private set;  } = null!;

    public string Value => $"{FirstName} {LastName}".Trim();

    protected FullName()
    {
    } 
    public FullName(string firstName, string lastName)
    {
        if (string.IsNullOrWhiteSpace(firstName))
            throw new ArgumentException("First name is required");

        if (string.IsNullOrWhiteSpace(lastName))
            throw new ArgumentException("Last name is required");

        FirstName = firstName.Trim();
        LastName = lastName.Trim();
    }
    
}