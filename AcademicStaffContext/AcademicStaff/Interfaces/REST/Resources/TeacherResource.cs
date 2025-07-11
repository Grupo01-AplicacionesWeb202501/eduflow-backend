using AcademicStaff.Application.Internal.CommandServices;
using AcademicStaff.Application.Internal.QueryServices;
using AcademicStaff.Domain.Model.Commands;
using AcademicStaff.Domain.Model.Queries;
using AcademicStaffContext.AcademicStaff.Domain.Model.Queries;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace AcademicStaff.Interfaces.REST.Resources
{
    [ApiController]
    [Route("api/v1/teachers")]
    public class TeacherResource : ControllerBase
    {
        private readonly TeacherCommandService _commandService;
        private readonly TeacherQueryService _queryService;

        public TeacherResource(TeacherCommandService commandService, TeacherQueryService queryService)
        {
            _commandService = commandService;
            _queryService = queryService;
        }

        [HttpGet]
        [SwaggerOperation(Summary = "Obtiene todos los profesores")]
        public async Task<IActionResult> GetAll()
        {
            var result = await _queryService.GetAllAsync(new GetAllTeachersQuery());
            return Ok(result);
        }

        [HttpGet("{id}")]
        [SwaggerOperation(Summary = "Obtiene un profesor por ID")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var result = await _queryService.GetByIdAsync(new GetTeacherByIdQuery(id));
            if (result == null) return NotFound();
            return Ok(result);
        }

        [HttpPost]
        [SwaggerOperation(Summary = "Crea un nuevo profesor")]
        public async Task<IActionResult> Create([FromBody] CreateTeacherCommand command)
        {
            try
            {
                var id = await _commandService.CreateAsync(command);
                return CreatedAtAction(nameof(GetById), new { id }, new { Id = id });
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }

        [HttpPut("{id}")]
        [SwaggerOperation(Summary = "Actualiza un profesor existente")]
        public async Task<IActionResult> Update(Guid id, [FromBody] UpdateTeacherCommand command)
        {
            if (id != command.Id) return BadRequest("El ID de la URL no coincide con el del cuerpo.");

            var success = await _commandService.UpdateAsync(command);
            if (!success) return NotFound();

            return NoContent();
        }

        [HttpDelete("{id}")]
        [SwaggerOperation(Summary = "Elimina un profesor")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var success = await _commandService.DeleteAsync(new DeleteTeacherCommand(id));
            if (!success) return NotFound();

            return NoContent();
        }

        [HttpGet("by-name")]
        [SwaggerOperation(Summary = "Obtener profesor por nombre")]
        public async Task<IActionResult> GetByName([FromQuery] string name)
        {
            var result = await _queryService.GetByNameAsync(new GetTeachersByNameQuery(name));
            return Ok(result);
        }
    }
}
