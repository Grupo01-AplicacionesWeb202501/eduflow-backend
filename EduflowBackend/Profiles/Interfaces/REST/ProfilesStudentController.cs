using EduflowBackend.Profiles.Domain.Model.Queries;
using EduflowBackend.Profiles.Domain.Services;
using EduflowBackend.Profiles.Interfaces.REST.Resources;
using EduflowBackend.Profiles.Interfaces.REST.Transform;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace EduflowBackend.Profiles.Interfaces.REST;


[ApiController]
[Route("api/v1/student-profiles")]
[Produces("application/json")]
[SwaggerTag("Endpoints for managing student profiles.")]
public class ProfilesStudentController(
    IStudentProfileCommandService commandService,
    IStudentProfileQueryService queryService)
    : ControllerBase
{
    [HttpPost]
    [SwaggerOperation("Create student profile", OperationId = "CreateStudentProfile")]
    [SwaggerResponse(201, "Profile created successfully", typeof(ProfileStudentResource))]
    public async Task<IActionResult> Create([FromBody] CreateProfileStudentResource resource)
    {
        var command = CreateProfileStudentCommandFromResourceAssembler.ToCommandFromResource(resource);
        var profile = await commandService.Handle(command);

        if (profile is null) return BadRequest();

        var result = ProfileStudentResourceFromEntityAssembler.ToResourceFromEntity(profile);
        return CreatedAtAction(nameof(GetById), new { profileId = profile.Id }, result);
    }

    [HttpGet("{profileId:int}")]
    [SwaggerOperation("Get student profile by ID", OperationId = "GetStudentProfileById")]
    [SwaggerResponse(200, "Profile retrieved", typeof(ProfileStudentResource))]
    public async Task<IActionResult> GetById(int profileId)
    {
        var query = new GetStudentProfileByIdQuery(profileId);
        var profile = await queryService.Handle(query);
        return profile is not null
            ? Ok(ProfileStudentResourceFromEntityAssembler.ToResourceFromEntity(profile))
            : NotFound();
    }

    [HttpGet]
    [SwaggerOperation("Get all student profiles", OperationId = "GetAllStudentProfiles")]
    [SwaggerResponse(200, "Profiles retrieved", typeof(IEnumerable<ProfileStudentResource>))]
    public async Task<IActionResult> GetAll()
    {
        var query = new GetAllStudentProfilesQuery();
        var result = await queryService.Handle(query);
        return Ok(result.Select(ProfileStudentResourceFromEntityAssembler.ToResourceFromEntity));
    }
}