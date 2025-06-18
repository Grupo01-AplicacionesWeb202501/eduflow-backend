using EduflowBackend.Profiles.Domain.Model.Aggregates;
using EduflowBackend.Profiles.Domain.Model.ValueObjects;
using EduflowBackend.Shared.Domain.Repositories;

namespace EduflowBackend.Profiles.Domain.Repositories;

/// <summary>
/// Profile repository interface 
/// </summary>
public interface IProfileRepository : IBaseRepository<Profile>
{
    /// <summary>
    /// Find a profile by email
    /// </summary>
    /// <param name="email">The email value object</param>
    /// <returns>The profile if found; otherwise, null</returns>
    Task<Profile?> FindByEmailAsync(Email email);

    /// <summary>
    /// List all profiles by user type
    /// </summary>
    /// <param name="userType">The user type value object</param>
    /// <returns>Enumerable of profiles with matching user type</returns>
    Task<IEnumerable<Profile>> ListByUserTypeAsync(UserType userType);
}