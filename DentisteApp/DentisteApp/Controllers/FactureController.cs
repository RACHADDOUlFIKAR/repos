using DentisteApp.IRepositories;
using DentisteApp.Models.Entities;
using Microsoft.AspNetCore.Mvc;


namespace DentisteApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FactureController : ControllerBase
    {
        private readonly IFactureRepository _factureRepository;

        public FactureController(IFactureRepository factureRepository)
        {
            _factureRepository = factureRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Facture>>> GetFactures()
        {
            return Ok(await _factureRepository.GetAllAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Facture>> GetFacture(int id)
        {
            var facture = await _factureRepository.GetByIdAsync(id);
            if (facture == null)
                return NotFound();
            return Ok(facture);
        }

        [HttpPost]
        public async Task<ActionResult> CreateFacture(Facture facture)
        {
            await _factureRepository.AddAsync(facture);
            return CreatedAtAction(nameof(GetFacture), new { id = facture.ID }, facture);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateFacture(int id, Facture facture)
        {
            if (id != facture.ID)
                return BadRequest();

            await _factureRepository.UpdateAsync(facture);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFacture(int id)
        {
            await _factureRepository.DeleteAsync(id);
            return NoContent();
        }
    }
}
