using EduflowBackend.Profiles.Domain.Model.Aggregates;
using EduflowBackend.Profiles.Domain.Model.Queries;
using EduflowBackend.Profiles.Domain.Repositories;
using EduflowBackend.Profiles.Domain.Services;

namespace EduflowBackend.Profiles.Application.Internal.QueryServices;

/// <summary>
/// Query service for handling student profile queries.
/// </summary>
public class StudentProfileQueryService(IStudentProfileRepository repository)
    : IStudentProfileQueryService
{
    public async Task<IEnumerable<ProfileStudent>> Handle(GetAllStudentProfilesQuery query)
    {
        return await repository.ListAsync();
    }

    public async Task<ProfileStudent?> Handle(GetStudentProfileByEmailQuery query)
    {
        return await repository.FindByEmailAsync(query.Email);
    }

    public async Task<ProfileStudent?> Handle(GetStudentProfileByIdQuery query)
    {
        return await repository.FindByIdAsync(query.ProfileId);
    }
}