namespace EduflowBackend.Profiles.Interfaces.ACL;

/// <summary>
/// Facade interface for accessing profile creation and queries across bounded contexts.
/// </summary>
public interface IProfilesContextFacade
{
    /// <summary>
    /// Creates a new student profile and returns its ID.
    /// </summary>
    Task<int> CreateStudentProfile(string firstName, string lastName, string email, string career, int cycle);

    /// <summary>
    /// Creates a new teacher profile and returns its ID.
    /// </summary>
    Task<int> CreateTeacherProfile(string firstName, string lastName, string email, string subject);

    /// <summary>
    /// Fetches the student profile ID associated with the given email.
    /// </summary>
    Task<int> FetchStudentProfileIdByEmail(string email);

    /// <summary>
    /// Fetches the teacher profile ID associated with the given email.
    /// </summary>
    Task<int> FetchTeacherProfileIdByEmail(string email);
}