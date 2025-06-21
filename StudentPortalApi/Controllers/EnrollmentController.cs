using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StudentPortalApi.Data;
using StudentPortalApi.Models;

namespace StudentPortalApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize(AuthenticationSchemes = "Bearer")]
    public class EnrollmentController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public EnrollmentController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> Enroll([FromBody] Enrollment model)
        {
            _context.Enrollments.Add(model);
            await _context.SaveChangesAsync();
            return Ok(new { Message = "Estudiante matriculado con éxito" });
        }

        [HttpGet("{studentId}")]
        public IActionResult GetEnrollments(string studentId)
        {
            var data = _context.Enrollments.Where(e => e.StudentId == studentId).ToList();
            return Ok(data);
        }
    }
}