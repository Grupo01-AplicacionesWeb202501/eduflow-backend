using EduflowBackend.Profiles.Domain.Model.Aggregates;
using EduflowBackend.Profiles.Interfaces.REST.Resources;

namespace EduflowBackend.Profiles.Interfaces.REST.Transform;

/// <summary>
/// Assembler for converting a TeacherProfile entity to TeacherProfileResource
/// </summary>
public static class TeacherProfileResourceFromEntityAssembler
{
    public static TeacherProfileResource ToResourceFromEntity(TeacherProfile entity)
    {
        return new TeacherProfileResource(
            entity.Id,
            entity.GetFullName(),
            entity.GetEmail(),
            entity.GetSubject()
        );
    }
}