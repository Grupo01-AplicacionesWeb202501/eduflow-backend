using EduflowBackend.Profiles.Domain.Model.Aggregates;
using EduflowBackend.Profiles.Domain.Model.Commands;

namespace EduflowBackend.Profiles.Domain.Services;

/// <summary>
/// Handles commands related to teacher profiles.
/// </summary>
public interface ITeacherProfileCommandService
{
    Task<TeacherProfile?> Handle(CreateTeacherProfileCommand command);
}