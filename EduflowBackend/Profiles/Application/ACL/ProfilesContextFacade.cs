using EduflowBackend.Profiles.Domain.Model.Commands;
using EduflowBackend.Profiles.Domain.Model.Queries;
using EduflowBackend.Profiles.Domain.Model.ValueObjects;
using EduflowBackend.Profiles.Domain.Services;
using EduflowBackend.Profiles.Interfaces.ACL;

namespace EduflowBackend.Profiles.Application.ACL;

/// <summary>
/// Facade implementation for interacting with the Profiles bounded context
/// </summary>
public class ProfilesContextFacade(
    IStudentProfileCommandService studentCommandService,
    ITeacherProfileCommandService teacherCommandService,
    IStudentProfileQueryService studentQueryService,
    ITeacherProfileQueryService teacherQueryService
) : IProfilesContextFacade
{
    public async Task<int> CreateStudentProfile(string firstName, string lastName, string email, string career, int cycle)
    {
        var command = new CreateStudentProfileCommand(firstName, lastName, email, career, cycle);
        var profile = await studentCommandService.Handle(command);
        return profile?.Id ?? 0;
    }

    public async Task<int> CreateTeacherProfile(string firstName, string lastName, string email, string subject)
    {
        var command = new CreateTeacherProfileCommand(firstName, lastName, email, subject);
        var profile = await teacherCommandService.Handle(command);
        return profile?.Id ?? 0;
    }

    public async Task<int> FetchStudentProfileIdByEmail(string email)
    {
        var query = new GetStudentProfileByEmailQuery(new Email(email));
        var profile = await studentQueryService.Handle(query);
        return profile?.Id ?? 0;
    }

    public async Task<int> FetchTeacherProfileIdByEmail(string email)
    {
        var query = new GetTeacherProfileByEmailQuery(new Email(email));
        var profile = await teacherQueryService.Handle(query);
        return profile?.Id ?? 0;
    }
}