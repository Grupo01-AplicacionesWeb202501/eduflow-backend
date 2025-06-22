using EduflowBackend.Profiles.Domain.Model.Commands;
using EduflowBackend.Profiles.Domain.Model.ValueObjects;

namespace EduflowBackend.Profiles.Domain.Model.Aggregates;

public partial class TeacherProfile
{
    public int Id { get; private set; }

    public FullName FullName { get; private set; } = null!;
    public Email Email { get; private set; } = null!;
    public Subject Subject { get; private set; } = null!;

    protected TeacherProfile() { }

    public TeacherProfile(CreateTeacherProfileCommand command)
    {
        FullName = new FullName(command.FirstName, command.LastName);
        Email = new Email(command.Email);
        Subject = new Subject(command.Subject);
    }

    public string GetFullName() => FullName.Value;
    public string GetEmail() => Email.Value;
    public string GetSubject() => Subject.Value;
}