namespace EduflowBackend.Profiles.Interfaces.REST.Resources;

/// <summary>
/// Resource used to create a student profile
/// </summary>
public record CreateProfileStudentResource(
    string FirstName,
    string LastName,
    string Email,
    string Career,
    int Cycle);