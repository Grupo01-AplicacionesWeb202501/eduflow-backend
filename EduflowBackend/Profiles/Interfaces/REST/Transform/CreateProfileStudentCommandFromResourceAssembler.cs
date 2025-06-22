using EduflowBackend.Profiles.Domain.Model.Commands;
using EduflowBackend.Profiles.Interfaces.REST.Resources;

namespace EduflowBackend.Profiles.Interfaces.REST.Transform;

/// <summary>
/// Assembler for converting a CreateProfileStudentResource to CreateProfileStudentCommand
/// </summary>
public static class CreateProfileStudentCommandFromResourceAssembler
{
    public static CreateStudentProfileCommand ToCommandFromResource(CreateProfileStudentResource resource)
    {
        return new CreateStudentProfileCommand(
            resource.FirstName,
            resource.LastName,
            resource.Email,
            resource.Career,
            resource.Cycle
        );
    }
}