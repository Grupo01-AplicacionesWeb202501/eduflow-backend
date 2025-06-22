using EduflowBackend.Profiles.Domain.Model.Aggregates;
using EduflowBackend.Profiles.Domain.Model.ValueObjects;
using EduflowBackend.Shared.Domain.Repositories;

namespace EduflowBackend.Profiles.Domain.Repositories;

public interface IStudentProfileRepository : IBaseRepository<ProfileStudent>
{
    /// <summary>
    /// Find a student profile by email.
    /// </summary>
    /// <param name="email">The email value object.</param>
    /// <returns>The matching StudentProfile or null if not found.</returns>
    Task<ProfileStudent?> FindByEmailAsync(Email email);
}