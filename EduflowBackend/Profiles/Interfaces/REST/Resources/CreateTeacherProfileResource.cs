namespace EduflowBackend.Profiles.Interfaces.REST.Resources;


/// <summary>
/// Resource used to create a teacher profile
/// </summary>
public record CreateTeacherProfileResource(
    string FirstName,
    string LastName,
    string Email,
    string Subject);