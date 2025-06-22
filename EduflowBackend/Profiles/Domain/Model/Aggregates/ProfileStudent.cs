using EduflowBackend.Profiles.Domain.Model.Commands;
using EduflowBackend.Profiles.Domain.Model.ValueObjects;

namespace EduflowBackend.Profiles.Domain.Model.Aggregates;

public partial class ProfileStudent
{
    public int Id { get; private set; }

    public FullName FullName { get; private set; }
    public Email Email { get; private set; }
    public Career Career { get; private set; }
    public Cycle Cycle { get; private set; }

    // Constructor requerido por EF
    protected ProfileStudent()
    {
        FullName = new FullName(); // usa el constructor protegido sin parámetros
        Email = new Email();
        Career = new Career();
        Cycle = new Cycle();
    }

    public ProfileStudent(CreateStudentProfileCommand command)
    {
        FullName = new FullName(command.FirstName, command.LastName);
        Email = new Email(command.Email);
        Career = new Career(command.Career);
        Cycle = new Cycle(command.CurrentCycle);
    }

    public string GetFullName() => FullName.Value;
    public string GetEmail() => Email.Value;
    public string GetCareer() => Career.Value;
    public int GetCycle() => Cycle.Value;
    
}