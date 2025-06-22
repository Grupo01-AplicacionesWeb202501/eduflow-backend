namespace EduflowBackend.Profiles.Domain.Model.Commands;

/// <summary>
/// Command to create a teacher profile
/// </summary>
/// <param name="FirstName">Teacher's first name</param>
/// <param name="LastName">Teacher's last name</param>
/// <param name="Email">Teacher's email</param>
/// <param name="Subject">Subject the teacher teaches</param>
public record CreateTeacherProfileCommand(
    string FirstName,
    string LastName,
    string Email,
    string Subject);