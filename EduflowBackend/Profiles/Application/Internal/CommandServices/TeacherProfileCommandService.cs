using EduflowBackend.Profiles.Domain.Model.Aggregates;
using EduflowBackend.Profiles.Domain.Model.Commands;
using EduflowBackend.Profiles.Domain.Repositories;
using EduflowBackend.Profiles.Domain.Services;
using EduflowBackend.Shared.Domain.Repositories;

namespace EduflowBackend.Profiles.Application.Internal.CommandServices;

/// <summary>
/// Command service for handling Teacher profile creation.
/// </summary>
public class TeacherProfileCommandService(
    ITeacherProfileRepository teacherProfileRepository,
    IUnitOfWork unitOfWork)
    : ITeacherProfileCommandService
{
    public async Task<TeacherProfile?> Handle(CreateTeacherProfileCommand command)
    {
        var profile = new TeacherProfile(command);
        try
        {
            await teacherProfileRepository.AddAsync(profile);
            await unitOfWork.CompleteAsync();
            return profile;
        }
        catch (Exception)
        {
            // Log the exception or handle it accordingly
            return null;
        }
    }
}