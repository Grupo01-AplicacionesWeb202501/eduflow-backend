using EduflowBackend.Profiles.Domain.Model.Queries;
using EduflowBackend.Profiles.Domain.Services;
using EduflowBackend.Profiles.Interfaces.REST.Resources;
using EduflowBackend.Profiles.Interfaces.REST.Transform;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace EduflowBackend.Profiles.Interfaces.REST;

[ApiController]
[Route("api/v1/teacher-profiles")]
[Produces("application/json")]
[SwaggerTag("Endpoints for managing teacher profiles.")]
public class ProfilesTeacherController(
    ITeacherProfileCommandService commandService,
    ITeacherProfileQueryService queryService)
    : ControllerBase
{
    [HttpPost]
    [SwaggerOperation("Create teacher profile", OperationId = "CreateTeacherProfile")]
    [SwaggerResponse(201, "Profile created successfully", typeof(TeacherProfileResource))]
    public async Task<IActionResult> Create([FromBody] CreateTeacherProfileResource resource)
    {
        var command = CreateTeacherProfileCommandFromResourceAssembler.ToCommandFromResource(resource);
        var profile = await commandService.Handle(command);

        if (profile is null) return BadRequest();

        var result = TeacherProfileResourceFromEntityAssembler.ToResourceFromEntity(profile);
        return CreatedAtAction(nameof(GetById), new { profileId = profile.Id }, result);
    }

    [HttpGet("{profileId:int}")]
    [SwaggerOperation("Get teacher profile by ID", OperationId = "GetTeacherProfileById")]
    [SwaggerResponse(200, "Profile retrieved", typeof(TeacherProfileResource))]
    public async Task<IActionResult> GetById(int profileId)
    {
        var query = new GetTeacherProfileByIdQuery(profileId);
        var profile = await queryService.Handle(query);
        return profile is not null
            ? Ok(TeacherProfileResourceFromEntityAssembler.ToResourceFromEntity(profile))
            : NotFound();
    }

    [HttpGet]
    [SwaggerOperation("Get all teacher profiles", OperationId = "GetAllTeacherProfiles")]
    [SwaggerResponse(200, "Profiles retrieved", typeof(IEnumerable<TeacherProfileResource>))]
    public async Task<IActionResult> GetAll()
    {
        var query = new GetAllTeacherProfilesQuery();
        var result = await queryService.Handle(query);
        return Ok(result.Select(TeacherProfileResourceFromEntityAssembler.ToResourceFromEntity));
    }
}