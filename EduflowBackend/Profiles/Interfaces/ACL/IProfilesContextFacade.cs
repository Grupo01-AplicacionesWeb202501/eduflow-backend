namespace EduflowBackend.Profiles.Interfaces.ACL;

/// <summary>
/// Facade for external modules to interact with the Profiles bounded context
/// </summary>
public interface IProfilesContextFacade
{
    /// <summary>
    /// Create a profile (student or teacher)
    /// </summary>
    /// <param name="fullName">Full name of the person</param>
    /// <param name="email">Email address</param>
    /// <param name="userType">"student" or "teacher"</param>
    /// <param name="career">Career (only for students)</param>
    /// <param name="currentCycle">Cycle (only for students)</param>
    /// <param name="subject">Subject taught (only for teachers)</param>
    /// <returns>Id of created profile, or 0 on failure</returns>
    Task<int> CreateProfileAsync(
        string fullName,
        string email,
        string userType,
        string? career = null,
        int? currentCycle = null,
        string? subject = null);

    /// <summary>
    /// Get profile ID from email
    /// </summary>
    /// <param name="email">Email to search</param>
    /// <returns>Profile ID or 0 if not found</returns>
    Task<int> FetchProfileIdByEmailAsync(string email);
}