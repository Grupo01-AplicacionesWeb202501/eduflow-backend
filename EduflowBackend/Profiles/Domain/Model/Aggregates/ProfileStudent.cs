using EduflowBackend.Profiles.Domain.Model.Commands;
using EduflowBackend.Profiles.Domain.Model.ValueObjects;

namespace EduflowBackend.Profiles.Domain.Model.Aggregates;

public partial class ProfileStudent
{
    public int Id { get; private set; }

    public FullName FullName { get; private set; } = null!;
    public Email Email { get; private set; } = null!;
    public Career Career { get; private set; } = null!;
    public Cycle Cycle { get; private set; } = null!;

 
    protected ProfileStudent() { }


    public ProfileStudent(CreateStudentProfileCommand command)
    {
        FullName = new FullName(command.FirstName, command.LastName);
        Email = new Email(command.Email);
        Career = new Career(command.Career);
        Cycle = new Cycle(command.CurrentCycle);
    }

 
    public string GetFullName() => FullName.Value;

    public string GetEmail() => Email.Value;
}