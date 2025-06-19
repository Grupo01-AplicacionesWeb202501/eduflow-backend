using EduflowBackend.Profiles.Domain.Model.Aggregates;
using EduflowBackend.Profiles.Domain.Model.Queries;
using EduflowBackend.Profiles.Domain.Repositories;
using EduflowBackend.Profiles.Domain.Services;

namespace EduflowBackend.Profiles.Application.Internal.QueryServices;

/// <summary>
/// Profile query service
/// </summary>
/// <param name="profileRepository">Profile repository</param>
public class ProfileQueryService(IProfileRepository profileRepository) : IProfileQueryService
{
    /// <inheritdoc />
    public async Task<IEnumerable<Profile>> Handle(ListAllProfilesQuery query)
    {
        return await profileRepository.ListAsync();
    }

    /// <inheritdoc />
    public async Task<Profile?> Handle(GetProfileByEmailQuery query)
    {
        return await profileRepository.FindByEmailAsync(query.Email);
    }

    /// <inheritdoc />
    public async Task<Profile?> Handle(GetProfileByIdQuery query)
    {
        return await profileRepository.FindByIdAsync(query.Id);
    }

    /// <inheritdoc />
    public async Task<IEnumerable<Profile>> Handle(ListProfilesByUserTypeQuery query)
    {
        return await profileRepository.ListByUserTypeAsync(query.UserType);
    }
}