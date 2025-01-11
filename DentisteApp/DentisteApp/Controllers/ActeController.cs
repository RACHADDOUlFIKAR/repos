using DentisteApp.IRepositories;
using DentisteApp.Models.Entities;
using Microsoft.AspNetCore.Mvc;

namespace DentisteApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActesController : ControllerBase
    {
        private readonly IActeRepository _acteRepository;

        public ActesController(IActeRepository acteRepository)
        {
            _acteRepository = acteRepository;
        }

        /// <summary>
        /// Récupère tous les actes avec leurs informations associées.
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> GetAllActes()
        {
            var actes = await _acteRepository.GetAllAsync();
            return Ok(actes);
        }

        /// <summary>
        /// Récupère un acte par son ID avec les informations associées.
        /// </summary>
        /// <param name="id">ID de l'acte</param>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetActeById(int id)
        {
            var acte = await _acteRepository.GetByIdAsync(id);
            if (acte == null)
                return NotFound(new { message = "Acte introuvable." });

            return Ok(acte);
        }

        /// <summary>
        /// Ajoute un nouvel acte après validation.
        /// </summary>
        /// <param name="acte">Acte à ajouter</param>
        [HttpPost]
        public async Task<IActionResult> AddActe([FromBody] Acte acte)
        {
            if (acte == null)
                return BadRequest(new { message = "Données invalides." });

            try
            {
                await _acteRepository.AddAsync(acte);
                return CreatedAtAction(nameof(GetActeById), new { id = acte.ID }, acte);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        /// <summary>
        /// Met à jour un acte existant.
        /// </summary>
        /// <param name="id">ID de l'acte à mettre à jour</param>
        /// <param name="acte">Données mises à jour de l'acte</param>
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateActe(int id, [FromBody] Acte acte)
        {
            if (id != acte.ID)
                return BadRequest(new { message = "L'ID de l'acte ne correspond pas." });

            if (acte == null)
                return BadRequest(new { message = "Données invalides." });

            try
            {
                await _acteRepository.UpdateAsync(acte);
                return NoContent();
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        /// <summary>
        /// Supprime un acte par son ID.
        /// </summary>
        /// <param name="id">ID de l'acte à supprimer</param>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteActe(int id)
        {
            var acte = await _acteRepository.GetByIdAsync(id);
            if (acte == null)
                return NotFound(new { message = "Acte introuvable." });

            await _acteRepository.DeleteAsync(id);
            return NoContent();
        }
    }
}
