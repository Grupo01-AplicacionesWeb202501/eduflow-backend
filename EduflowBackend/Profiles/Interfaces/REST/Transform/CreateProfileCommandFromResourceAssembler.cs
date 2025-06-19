using EduflowBackend.Profiles.Domain.Model.Commands;
using EduflowBackend.Profiles.Interfaces.REST.Resources;

namespace EduflowBackend.Profiles.Interfaces.REST.Transform;

/// <summary>
/// Assembler to transform CreateProfileResource into CreateProfileCommand
/// </summary>
public static class CreateProfileCommandFromResourceAssembler
{
    public static CreateProfilesCommand ToCommandFromResource(CreateProfileResource resource)
    {
        return new CreateProfilesCommand(
            resource.FullName,
            resource.Email,
            resource.UserType,
            resource.Career,
            resource.CurrentCycle,
            resource.Subject
        );
    }
}