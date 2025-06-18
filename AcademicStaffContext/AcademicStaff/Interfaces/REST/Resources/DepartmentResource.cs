using AcademicStaffContext.AcademicStaff.Application.Internal.CommandServices;
using AcademicStaffContext.AcademicStaff.Application.Internal.QueryServices;
using AcademicStaffContext.AcademicStaff.Domain.Model.Commands;
using AcademicStaffContext.AcademicStaff.Domain.Model.Queries;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace AcademicStaffContext.AcademicStaff.Interfaces.REST.Resources
{
    [ApiController]
    [Route("api/v1/departments")]
    public class DepartmentResource : ControllerBase
    {
        private readonly DepartmentCommandService _commandService;
        private readonly DepartmentQueryService _queryService;

        public DepartmentResource(
            DepartmentCommandService commandService,
            DepartmentQueryService queryService)
        {
            _commandService = commandService;
            _queryService = queryService;
        }

        // POST: api/v1/departments
        [HttpPost]
        [SwaggerOperation(Summary = "Crear Departamento")]
        public async Task<IActionResult> Create([FromBody] CreateDepartmentCommand command)
        {
            var id = await _commandService.CreateAsync(command);
            return CreatedAtAction(nameof(GetById), new { id }, new { id });
        }

        // PUT: api/v1/departments/{id}
        [HttpPut("{id}")]
        [SwaggerOperation(Summary = "Actualizar departamento")]
        public async Task<IActionResult> Update(Guid id, [FromBody] UpdateDepartmentCommand command)
        {
            if (id != command.Id)
                return BadRequest("El ID de la ruta no coincide con el del cuerpo de la solicitud.");

            var result = await _commandService.UpdateAsync(command);
            if (!result) return NotFound();

            return NoContent();
        }

        // DELETE: api/v1/departments/{id}
        [HttpDelete("{id}")]
        [SwaggerOperation(Summary = "Borrar Departamento")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var result = await _commandService.DeleteAsync(new DeleteDepartmentCommand(id));
            if (!result) return NotFound();

            return NoContent();
        }

        // GET: api/v1/departments
        [HttpGet]
        [SwaggerOperation(Summary = "Obtener todos los departamentos")]
        public async Task<IActionResult> GetAll()
        {
            var query = new GetAllDepartmentsQuery();
            var departments = await _queryService.Handle(query);
            return Ok(departments);
        }

        // GET: api/v1/departments/{id}
        [HttpGet("{id}")]
        [SwaggerOperation(Summary = "Obtener departamento por ID")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var query = new GetDepartmentByIdQuery(id);
            var department = await _queryService.Handle(query);
            if (department == null) return NotFound();
            return Ok(department);
        }
    }
}
