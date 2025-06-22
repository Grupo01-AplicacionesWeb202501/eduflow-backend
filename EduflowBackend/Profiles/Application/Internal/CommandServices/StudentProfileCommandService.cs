using EduflowBackend.Profiles.Domain.Model.Aggregates;
using EduflowBackend.Profiles.Domain.Model.Commands;
using EduflowBackend.Profiles.Domain.Repositories;
using EduflowBackend.Profiles.Domain.Services;
using EduflowBackend.Shared.Domain.Repositories;

namespace EduflowBackend.Profiles.Application.Internal.CommandServices;

/// <summary>
/// Command service for handling Student profile creation.
/// </summary>
public class StudentProfileCommandService(
    IStudentProfileRepository studentProfileRepository,
    IUnitOfWork unitOfWork)
    : IStudentProfileCommandService
{
    public async Task<ProfileStudent?> Handle(CreateStudentProfileCommand command)
    {
        var profile = new ProfileStudent(command);
        try
        {
            await studentProfileRepository.AddAsync(profile);
            await unitOfWork.CompleteAsync();
            return profile;
        }
        catch (Exception)
        {
            // You could log the exception here
            return null;
        }
    }
}