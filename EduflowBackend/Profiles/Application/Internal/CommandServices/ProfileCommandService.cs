using EduflowBackend.Profiles.Domain.Model.Aggregates;
using EduflowBackend.Profiles.Domain.Model.Commands;
using EduflowBackend.Profiles.Domain.Repositories;
using EduflowBackend.Profiles.Domain.Services;
using EduflowBackend.Shared.Domain.Repositories;

namespace EduflowBackend.Profiles.Application.Internal.CommandServices;

/// <summary>
/// Profile command service
/// </summary>
/// <param name="profileRepository">Profile repository</param>
/// <param name="unitOfWork">Unit of work</param>
public class ProfileCommandService(
    IProfileRepository profileRepository,
    IUnitOfWork unitOfWork
) : IProfileCommandService
{
    /// <inheritdoc />
    public async Task<Profile?> Handle(CreateProfilesCommand command)
    {
        var profile = new Profile(command);
        try
        {
            await profileRepository.AddAsync(profile);
            await unitOfWork.CompleteAsync();
            return profile;
        }
        catch (Exception e)
        {
            // Log error (optional: inject a logger)
            return null;
        }
    }
}