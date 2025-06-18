using EduflowBackend.Profiles.Domain.Model.Commands;
using EduflowBackend.Profiles.Domain.Model.ValueObjects;

namespace EduflowBackend.Profiles.Domain.Model.Aggregates;

public partial class Profile
{
    public int Id { get; private set; }

    public FullName FullName { get; private set; }
    public Email Email { get; private set; }
    public UserType UserType { get; private set; }

    public string? Career { get; private set; }
    public int? CurrentCycle { get; private set; }
    public string? Subject { get; private set; }

    public DateTime CreatedAt { get; private set; }
    public DateTime UpdatedAt { get; private set; }

    // EF Core requires empty constructor
    protected Profile() {}

    // ✅ Constructor desde el Command
    public Profile(CreateProfilesCommand command)
    {
        FullName = new FullName(command.FullName);
        Email = new Email(command.Email);
        UserType = new UserType(command.UserType);

        if (UserType.ToString() == "student")
        {
            Career = command.Career ?? throw new ArgumentException("Career is required for students.");
            CurrentCycle = command.CurrentCycle ?? throw new ArgumentException("Current cycle is required for students.");
        }

        if (UserType.ToString() == "teacher")
        {
            Subject = command.Subject ?? throw new ArgumentException("Subject is required for teachers.");
        }
    }
}