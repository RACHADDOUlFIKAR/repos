using DentisteApp.IRepositories;
using DentisteApp.Models.Entities;
using Microsoft.AspNetCore.Mvc;


namespace DentisteApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaiementController : ControllerBase
    {
        private readonly IPaiementRepository _paiementRepository;

        public PaiementController(IPaiementRepository paiementRepository)
        {
            _paiementRepository = paiementRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Paiement>>> GetPaiements()
        {
            return Ok(await _paiementRepository.GetAllAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Paiement>> GetPaiement(int id)
        {
            var paiement = await _paiementRepository.GetByIdAsync(id);
            if (paiement == null)
                return NotFound();
            return Ok(paiement);
        }

        [HttpPost]
        public async Task<ActionResult> CreatePaiement(Paiement paiement)
        {
            await _paiementRepository.AddAsync(paiement);
            return CreatedAtAction(nameof(GetPaiement), new { id = paiement.ID }, paiement);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePaiement(int id, Paiement paiement)
        {
            if (id != paiement.ID)
                return BadRequest();

            await _paiementRepository.UpdateAsync(paiement);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePaiement(int id)
        {
            await _paiementRepository.DeleteAsync(id);
            return NoContent();
        }
    }
}
