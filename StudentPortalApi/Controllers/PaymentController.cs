using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StudentPortalApi.Data;
using StudentPortalApi.Models;

namespace StudentPortalApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize(AuthenticationSchemes = "Bearer")]
    public class PaymentController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public PaymentController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> MakePayment([FromBody] Payment model)
        {
            _context.Payments.Add(model);
            await _context.SaveChangesAsync();
            return Ok(new { Message = "Pago registrado con éxito" });
        }

        [HttpGet("{studentId}")]
        public IActionResult GetPayments(string studentId)
        {
            var data = _context.Payments.Where(p => p.StudentId == studentId).ToList();
            return Ok(data);
        }
    }
}