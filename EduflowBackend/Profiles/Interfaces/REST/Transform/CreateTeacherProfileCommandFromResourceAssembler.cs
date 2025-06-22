using EduflowBackend.Profiles.Domain.Model.Commands;
using EduflowBackend.Profiles.Interfaces.REST.Resources;

namespace EduflowBackend.Profiles.Interfaces.REST.Transform;

/// <summary>
/// Assembler for converting a CreateTeacherProfileResource to CreateTeacherProfileCommand
/// </summary>
public static class CreateTeacherProfileCommandFromResourceAssembler
{
    public static CreateTeacherProfileCommand ToCommandFromResource(CreateTeacherProfileResource resource)
    {
        return new CreateTeacherProfileCommand(
            resource.FirstName,
            resource.LastName,
            resource.Email,
            resource.Subject
        );
    }
}