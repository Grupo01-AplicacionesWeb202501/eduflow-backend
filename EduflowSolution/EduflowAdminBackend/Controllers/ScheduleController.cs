using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EduflowAdminBackend.Data;
using EduflowAdminBackend.Models;

namespace EduflowAdminBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ScheduleController : ControllerBase
    {
        private readonly AdminContext _context;

        public ScheduleController(AdminContext context)
        {
            _context = context;
        }

        // GET: api/schedule
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Schedule>>> GetSchedules()
        {
            return await _context.Schedules.Include(s => s.Course).ToListAsync();
        }

        // GET: api/schedule/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Schedule>> GetSchedule(int id)
        {
            var schedule = await _context.Schedules.Include(s => s.Course).FirstOrDefaultAsync(s => s.Id == id);
            if (schedule == null)
            {
                return NotFound();
            }
            return schedule;
        }

        // POST: api/schedule
        [HttpPost]
        public async Task<ActionResult<Schedule>> PostSchedule([FromBody] Schedule schedule)
        {
            if (schedule == null || schedule.CourseId <= 0)
            {
                return BadRequest("CourseId is required and must be greater than 0.");
            }

            // Ignorar el objeto Course anidado y usar solo CourseId para la relación
            schedule.Course = null; // Evitar que se intente guardar el objeto Course anidado
            _context.Schedules.Add(schedule);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetSchedule), new { id = schedule.Id }, schedule);
        }

        // PUT: api/schedule/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSchedule(int id, Schedule schedule)
        {
            if (id != schedule.Id)
            {
                return BadRequest();
            }

            _context.Entry(schedule).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        // DELETE: api/schedule/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSchedule(int id)
        {
            var schedule = await _context.Schedules.FindAsync(id);
            if (schedule == null)
            {
                return NotFound();
            }

            _context.Schedules.Remove(schedule);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}