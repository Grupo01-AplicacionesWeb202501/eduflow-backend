using EduflowBackend.Profiles.Domain.Model.Aggregates;
using EduflowBackend.Profiles.Domain.Model.Queries;

namespace EduflowBackend.Profiles.Domain.Services;

public interface IStudentProfileQueryService
{
    Task<IEnumerable<ProfileStudent>> Handle(GetAllStudentProfilesQuery query);
    Task<ProfileStudent?> Handle(GetStudentProfileByEmailQuery query);
    Task<ProfileStudent?> Handle(GetStudentProfileByIdQuery query);
}