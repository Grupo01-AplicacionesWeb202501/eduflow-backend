namespace EduflowBackend.Profiles.Interfaces.REST.Resources;

/// <summary>
/// Profile resource for REST API responses
/// </summary>
/// <param name="Id">Unique identifier of the profile</param>
/// <param name="FullName">Full name of the user</param>
/// <param name="Email">Email address</param>
/// <param name="UserType">Type of user: "student" or "teacher"</param>
/// <param name="Career">Career (for students)</param>
/// <param name="CurrentCycle">Cycle (for students)</param>
/// <param name="Subject">Subject taught (for teachers)</param>
public record ProfileResource(
    int Id,
    string FullName,
    string Email,
    string UserType,
    string? Career = null,
    int? CurrentCycle = null,
    string? Subject = null);