using EduflowBackend.Profiles.Domain.Model.Aggregates;
using EduflowBackend.Profiles.Interfaces.REST.Resources;

namespace EduflowBackend.Profiles.Interfaces.REST.Transform;

/// <summary>
/// Assembler to transform Profile aggregate into ProfileResource
/// </summary>
public static class ProfileResourceFromEntityAssembler
{
    public static ProfileResource ToResourceFromEntity(Profile entity)
    {
        return new ProfileResource(
            entity.Id,
            entity.FullName.Value,
            entity.Email.Address,
            entity.UserType.Value,
            entity.Career,
            entity.CurrentCycle,
            entity.Subject
        );
    }
}