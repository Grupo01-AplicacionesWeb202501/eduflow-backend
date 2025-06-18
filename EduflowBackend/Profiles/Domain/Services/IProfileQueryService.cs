using EduflowBackend.Profiles.Domain.Model.Aggregates;
using EduflowBackend.Profiles.Domain.Model.Queries;

namespace EduflowBackend.Profiles.Domain.Services;

/// <summary>
/// Profile query service interface
/// </summary>
public interface IProfileQueryService
{
    /// <summary>
    /// Handle retrieving all profiles
    /// </summary>
    Task<IEnumerable<Profile>> Handle(ListAllProfilesQuery query);

    /// <summary>
    /// Handle retrieving a profile by email
    /// </summary>
    Task<Profile?> Handle(GetProfileByEmailQuery query);

    /// <summary>
    /// Handle retrieving a profile by ID
    /// </summary>
    Task<Profile?> Handle(GetProfileByIdQuery query);

    /// <summary>
    /// Handle retrieving profiles by user type
    /// </summary>
    Task<IEnumerable<Profile>> Handle(ListProfilesByUserTypeQuery query);
}