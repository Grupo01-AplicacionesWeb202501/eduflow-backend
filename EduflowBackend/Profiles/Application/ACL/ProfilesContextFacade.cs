using EduflowBackend.Profiles.Domain.Model.Commands;
using EduflowBackend.Profiles.Domain.Model.Queries;
using EduflowBackend.Profiles.Domain.Model.ValueObjects;
using EduflowBackend.Profiles.Domain.Services;
using EduflowBackend.Profiles.Interfaces.ACL;

namespace EduflowBackend.Profiles.Application.ACL;

/// <summary>
/// ACL Facade for the Profiles Bounded Context
/// </summary>
/// <param name="profileCommandService">Command handler for profile creation</param>
/// <param name="profileQueryService">Query handler for profile retrieval</param>
public class ProfilesContextFacade(
    IProfileCommandService profileCommandService,
    IProfileQueryService profileQueryService
) : IProfilesContextFacade
{
    /// <inheritdoc />
    public async Task<int> CreateProfileAsync(
        string fullName,
        string email,
        string userType,
        string? career = null,
        int? currentCycle = null,
        string? subject = null)
    {
        var command = new CreateProfilesCommand(
            fullName,
            email,
            userType,
            career,
            currentCycle,
            subject
        );

        var profile = await profileCommandService.Handle(command);
        return profile?.Id ?? 0;
    }

    /// <inheritdoc />
    public async Task<int> FetchProfileIdByEmailAsync(string email)
    {
        var query = new GetProfileByEmailQuery(email);
        var profile = await profileQueryService.Handle(query);
        return profile?.Id ?? 0;
    }
}