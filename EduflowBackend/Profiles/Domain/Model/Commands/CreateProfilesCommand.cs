namespace EduflowBackend.Profiles.Domain.Model.Commands;

/// <summary>
/// Command to request creation of a new profile (student or teacher)
/// </summary>
public record CreateProfilesCommand(
    string FullName,
    string Email,
    string UserType,          // "student" or "teacher"
    string? Career = null,    // Only for students
    int? CurrentCycle = null, // Only for students
    string? Subject = null    // Only for teachers
);