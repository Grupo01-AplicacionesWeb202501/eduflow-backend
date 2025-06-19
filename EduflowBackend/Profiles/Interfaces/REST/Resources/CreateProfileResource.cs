namespace EduflowBackend.Profiles.Interfaces.REST.Resources;

/// <summary>
/// Resource for creating a new profile (student or teacher)
/// </summary>
/// <param name="FullName">Full name of the user</param>
/// <param name="Email">Email address</param>
/// <param name="UserType">User type: "student" or "teacher"</param>
/// <param name="Career">Career (for students)</param>
/// <param name="CurrentCycle">Cycle (for students)</param>
/// <param name="Subject">Subject (for teachers)</param>
public record CreateProfileResource(
    string FullName,
    string Email,
    string UserType,
    string? Career = null,
    int? CurrentCycle = null,
    string? Subject = null);