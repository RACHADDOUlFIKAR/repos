using DentisteApp.IRepositories;
using DentisteApp.Models.Entities;
using Microsoft.AspNetCore.Mvc;


namespace DentisteApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImagerieController : ControllerBase
    {
        private readonly IImagerieRepository _imagerieRepository;

        public ImagerieController(IImagerieRepository imagerieRepository)
        {
            _imagerieRepository = imagerieRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Imagerie>>> GetImageries()
        {
            return Ok(await _imagerieRepository.GetAllAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Imagerie>> GetImagerie(int id)
        {
            var imagerie = await _imagerieRepository.GetByIdAsync(id);
            if (imagerie == null)
                return NotFound();
            return Ok(imagerie);
        }

        [HttpPost]
        public async Task<ActionResult> CreateImagerie(Imagerie imagerie)
        {
            await _imagerieRepository.AddAsync(imagerie);
            return CreatedAtAction(nameof(GetImagerie), new { id = imagerie.ID }, imagerie);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateImagerie(int id, Imagerie imagerie)
        {
            if (id != imagerie.ID)
                return BadRequest();

            await _imagerieRepository.UpdateAsync(imagerie);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteImagerie(int id)
        {
            await _imagerieRepository.DeleteAsync(id);
            return NoContent();
        }
    }
}
