namespace EduflowBackend.Profiles.Interfaces.REST.Resources;

/// <summary>
/// Resource representing a student profile
/// </summary>
public record ProfileStudentResource(
    int Id,
    string FullName,
    string Email,
    string Career,
    int Cycle);