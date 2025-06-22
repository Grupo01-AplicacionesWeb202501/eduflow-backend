using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EduflowAdminBackend.Data;
using EduflowAdminBackend.Models;

namespace EduflowAdminBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AcademicPeriodController : ControllerBase
    {
        private readonly AdminContext _context;

        public AcademicPeriodController(AdminContext context)
        {
            _context = context;
        }

        // GET: api/academicperiod
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AcademicPeriod>>> GetAcademicPeriods()
        {
            return await _context.AcademicPeriods.ToListAsync();
        }

        // GET: api/academicperiod/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AcademicPeriod>> GetAcademicPeriod(int id)
        {
            var period = await _context.AcademicPeriods.FindAsync(id);
            if (period == null)
            {
                return NotFound();
            }
            return period;
        }

        // POST: api/academicperiod
        [HttpPost]
        public async Task<ActionResult<AcademicPeriod>> PostAcademicPeriod(AcademicPeriod period)
        {
            _context.AcademicPeriods.Add(period);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetAcademicPeriod), new { id = period.Id }, period);
        }

        // PUT: api/academicperiod/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAcademicPeriod(int id, AcademicPeriod period)
        {
            if (id != period.Id)
            {
                return BadRequest();
            }

            _context.Entry(period).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        // DELETE: api/academicperiod/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAcademicPeriod(int id)
        {
            var period = await _context.AcademicPeriods.FindAsync(id);
            if (period == null)
            {
                return NotFound();
            }

            _context.AcademicPeriods.Remove(period);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
