using EduflowBackend.Profiles.Domain.Model.Commands;
using EduflowBackend.Profiles.Domain.Model.ValueObjects;

namespace EduflowBackend.Profiles.Domain.Model.Aggregates;

public partial class TeacherProfile
{
    public int Id { get; private set; }

    public FullName FullName { get; private set; }
    public Email Email { get; private set; }
    public Subject Subject { get; private set; }

    // Constructor requerido por EF
   protected TeacherProfile()
    {
        FullName = new FullName();
        Email = new Email();
        Subject = new Subject();
    }

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