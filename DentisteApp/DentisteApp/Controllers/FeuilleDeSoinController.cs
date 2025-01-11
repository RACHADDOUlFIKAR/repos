using DentisteApp.IRepositories;
using DentisteApp.Models.Entities;
using Microsoft.AspNetCore.Mvc;


namespace DentisteApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeuilleDeSoinController : ControllerBase
    {
        private readonly IFeuilleDeSoinRepository _feuilleDeSoinRepository;

        public FeuilleDeSoinController(IFeuilleDeSoinRepository feuilleDeSoinRepository)
        {
            _feuilleDeSoinRepository = feuilleDeSoinRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<FeuilleDeSoin>>> GetFeuillesDeSoin()
        {
            return Ok(await _feuilleDeSoinRepository.GetAllAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<FeuilleDeSoin>> GetFeuilleDeSoin(int id)
        {
            var feuille = await _feuilleDeSoinRepository.GetByIdAsync(id);
            if (feuille == null)
                return NotFound();
            return Ok(feuille);
        }

        [HttpPost]
        public async Task<ActionResult> CreateFeuilleDeSoin(FeuilleDeSoin feuilleDeSoin)
        {
            await _feuilleDeSoinRepository.AddAsync(feuilleDeSoin);
            return CreatedAtAction(nameof(GetFeuilleDeSoin), new { id = feuilleDeSoin.ID }, feuilleDeSoin);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateFeuilleDeSoin(int id, FeuilleDeSoin feuilleDeSoin)
        {
            if (id != feuilleDeSoin.ID)
                return BadRequest();

            await _feuilleDeSoinRepository.UpdateAsync(feuilleDeSoin);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFeuilleDeSoin(int id)
        {
            await _feuilleDeSoinRepository.DeleteAsync(id);
            return NoContent();
        }
    }
}
