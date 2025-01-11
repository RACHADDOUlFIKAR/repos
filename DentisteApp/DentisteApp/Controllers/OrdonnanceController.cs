using DentisteApp.IRepositories;
using DentisteApp.Models.Entities;
using Microsoft.AspNetCore.Mvc;


namespace DentisteApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdonnanceController : ControllerBase
    {
        private readonly IOrdonnanceRepository _ordonnanceRepository;

        public OrdonnanceController(IOrdonnanceRepository ordonnanceRepository)
        {
            _ordonnanceRepository = ordonnanceRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Ordonnance>>> GetOrdonnances()
        {
            return Ok(await _ordonnanceRepository.GetAllAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Ordonnance>> GetOrdonnance(int id)
        {
            var ordonnance = await _ordonnanceRepository.GetByIdAsync(id);
            if (ordonnance == null)
                return NotFound();
            return Ok(ordonnance);
        }

        [HttpPost]
        public async Task<ActionResult> CreateOrdonnance(Ordonnance ordonnance)
        {
            await _ordonnanceRepository.AddAsync(ordonnance);
            return CreatedAtAction(nameof(GetOrdonnance), new { id = ordonnance.ID }, ordonnance);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateOrdonnance(int id, Ordonnance ordonnance)
        {
            if (id != ordonnance.ID)
                return BadRequest();

            await _ordonnanceRepository.UpdateAsync(ordonnance);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrdonnance(int id)
        {
            await _ordonnanceRepository.DeleteAsync(id);
            return NoContent();
        }
    }
}
