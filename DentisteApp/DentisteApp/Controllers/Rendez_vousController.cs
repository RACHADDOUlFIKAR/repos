using DentisteApp.IRepositories;
using DentisteApp.Models.Entities;
using Microsoft.AspNetCore.Mvc;

namespace DentisteApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class Rendez_vousController : ControllerBase
    {
        private readonly IRendez_vousRepository _rendezVousRepository;

        public Rendez_vousController(IRendez_vousRepository rendezVousRepository)
        {
            _rendezVousRepository = rendezVousRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var rendezVous = await _rendezVousRepository.GetAllAsync();
            return Ok(rendezVous);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var rendezVous = await _rendezVousRepository.GetByIdAsync(id);
            if (rendezVous == null)
            {
                return NotFound();
            }
            return Ok(rendezVous);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Rendez_vous rendezVous)
        {
            if (rendezVous == null)
            {
                return BadRequest();
            }

            await _rendezVousRepository.AddAsync(rendezVous);
            return CreatedAtAction(nameof(GetById), new { id = rendezVous.Id }, rendezVous);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Rendez_vous rendezVous)
        {
            if (id != rendezVous.Id)
            {
                return BadRequest();
            }

            var existingRendezVous = await _rendezVousRepository.GetByIdAsync(id);
            if (existingRendezVous == null)
            {
                return NotFound();
            }

            await _rendezVousRepository.UpdateAsync(rendezVous);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var rendezVous = await _rendezVousRepository.GetByIdAsync(id);
            if (rendezVous == null)
            {
                return NotFound();
            }

            await _rendezVousRepository.DeleteAsync(id);
            return NoContent();
        }
    }
}
