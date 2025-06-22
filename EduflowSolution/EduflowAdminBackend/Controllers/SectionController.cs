using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EduflowAdminBackend.Data;
using EduflowAdminBackend.Models;

namespace EduflowAdminBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SectionController : ControllerBase
    {
        private readonly AdminContext _context;

        public SectionController(AdminContext context)
        {
            _context = context;
        }

        // GET: api/section
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Section>>> GetSections()
        {
            return await _context.Sections.Include(s => s.Course).ToListAsync();
        }

        // GET: api/section/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Section>> GetSection(int id)
        {
            var section = await _context.Sections.Include(s => s.Course).FirstOrDefaultAsync(s => s.Id == id);
            if (section == null)
            {
                return NotFound();
            }
            return section;
        }

        // POST: api/section
        [HttpPost]
        public async Task<ActionResult<Section>> PostSection(Section section)
        {
            _context.Sections.Add(section);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetSection), new { id = section.Id }, section);
        }

        // PUT: api/section/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSection(int id, Section section)
        {
            if (id != section.Id)
            {
                return BadRequest();
            }

            _context.Entry(section).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        // DELETE: api/section/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSection(int id)
        {
            var section = await _context.Sections.FindAsync(id);
            if (section == null)
            {
                return NotFound();
            }

            _context.Sections.Remove(section);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}