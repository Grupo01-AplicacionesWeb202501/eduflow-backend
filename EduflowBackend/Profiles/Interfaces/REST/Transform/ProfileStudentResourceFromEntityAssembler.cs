using EduflowBackend.Profiles.Domain.Model.Aggregates;
using EduflowBackend.Profiles.Interfaces.REST.Resources;

namespace EduflowBackend.Profiles.Interfaces.REST.Transform;

/// <summary>
/// Assembler for converting a ProfileStudent entity to ProfileStudentResource
/// </summary>
public static class ProfileStudentResourceFromEntityAssembler
{
    public static ProfileStudentResource ToResourceFromEntity(ProfileStudent entity)
    {
        return new ProfileStudentResource(
            entity.Id,
            entity.GetFullName(),
            entity.GetEmail(),
            entity.GetCareer(),
            entity.GetCycle()
        );
    }
}