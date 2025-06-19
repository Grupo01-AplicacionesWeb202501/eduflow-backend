using EduflowBackend.Profiles.Domain.Model.ValueObjects;

namespace EduflowBackend.Profiles.Domain.Model.Queries;

public record GetProfileByEmailQuery(Email Email);