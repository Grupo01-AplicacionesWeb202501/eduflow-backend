namespace EduflowBackend.Profiles.Domain.Model.Commands;

/// <summary>
/// Command to create a student profile
/// </summary>
/// <param name="FirstName">Student's first name</param>
/// <param name="LastName">Student's last name</param>
/// <param name="Email">Student's email</param>
/// <param name="Career">Student's career</param>
/// <param name="CurrentCycle">Current academic cycle</param>
public record CreateStudentProfileCommand(
    string FirstName,
    string LastName,
    string Email,
    string Career,
    int CurrentCycle);