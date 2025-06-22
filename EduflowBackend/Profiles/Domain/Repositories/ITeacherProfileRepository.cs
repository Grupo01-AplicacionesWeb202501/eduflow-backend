using EduflowBackend.Profiles.Domain.Model.Aggregates;
using EduflowBackend.Profiles.Domain.Model.ValueObjects;
using EduflowBackend.Shared.Domain.Repositories;

namespace EduflowBackend.Profiles.Domain.Repositories;

public interface ITeacherProfileRepository : IBaseRepository<TeacherProfile>
{
    /// <summary>
    /// Find a teacher profile by email.
    /// </summary>
    /// <param name="email">Email address to search.</param>
    /// <returns>The matching TeacherProfile or null if not found.</returns>
    Task<TeacherProfile?> FindByEmailAsync(Email email);
}