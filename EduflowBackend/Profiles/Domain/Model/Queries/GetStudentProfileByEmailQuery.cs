using EduflowBackend.Profiles.Domain.Model.ValueObjects;

namespace EduflowBackend.Profiles.Domain.Model.Queries;

public record GetStudentProfileByEmailQuery(Email Email);