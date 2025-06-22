namespace EduflowBackend.Profiles.Interfaces.REST.Resources;

/// <summary>
/// Resource representing a teacher profile
/// </summary>
public record TeacherProfileResource(
    int Id,
    string FullName,
    string Email,
    string Subject);
    