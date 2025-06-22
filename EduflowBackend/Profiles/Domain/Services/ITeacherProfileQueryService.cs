using EduflowBackend.Profiles.Domain.Model.Aggregates;
using EduflowBackend.Profiles.Domain.Model.Queries;

namespace EduflowBackend.Profiles.Domain.Services;

/// <summary>
/// Handles queries related to teacher profiles.
/// </summary>
public interface ITeacherProfileQueryService
{
    Task<IEnumerable<TeacherProfile>> Handle(GetAllTeacherProfilesQuery query);
    Task<TeacherProfile?> Handle(GetTeacherProfileByEmailQuery query);
    Task<TeacherProfile?> Handle(GetTeacherProfileByIdQuery query);
}