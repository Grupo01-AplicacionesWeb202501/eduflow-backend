using EduflowBackend.Profiles.Domain.Model.Aggregates;
using EduflowBackend.Profiles.Domain.Model.Queries;
using EduflowBackend.Profiles.Domain.Repositories;
using EduflowBackend.Profiles.Domain.Services;

namespace EduflowBackend.Profiles.Application.Internal.QueryServices;

/// <summary>
/// Query service for handling teacher profile queries.
/// </summary>
public class TeacherProfileQueryService(ITeacherProfileRepository repository)
    : ITeacherProfileQueryService
{
    public async Task<IEnumerable<TeacherProfile>> Handle(GetAllTeacherProfilesQuery query)
    {
        return await repository.ListAsync();
    }

    public async Task<TeacherProfile?> Handle(GetTeacherProfileByEmailQuery query)
    {
        return await repository.FindByEmailAsync(query.Email);
    }

    public async Task<TeacherProfile?> Handle(GetTeacherProfileByIdQuery query)
    {
        return await repository.FindByIdAsync(query.ProfileId);
    }
}