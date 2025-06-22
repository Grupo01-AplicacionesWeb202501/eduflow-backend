using EduflowBackend.Profiles.Domain.Model.Aggregates;
using EduflowBackend.Profiles.Domain.Model.Commands;

namespace EduflowBackend.Profiles.Domain.Services;

/// <summary>
/// Handles commands related to student profiles.
/// </summary>
public interface IStudentProfileCommandService
{
    Task<ProfileStudent?> Handle(CreateStudentProfileCommand command);
}