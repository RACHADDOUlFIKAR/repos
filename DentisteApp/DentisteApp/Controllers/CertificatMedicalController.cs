using DentisteApp.IRepositories;
using DentisteApp.Models.Entities;
using Microsoft.AspNetCore.Mvc;


namespace DentisteApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CertificatMedicalController : ControllerBase
    {
        private readonly ICertificatMedicalRepository _certificatMedicalRepository;

        public CertificatMedicalController(ICertificatMedicalRepository certificatMedicalRepository)
        {
            _certificatMedicalRepository = certificatMedicalRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CertificatMedical>>> GetCertificatsMedicaux()
        {
            return Ok(await _certificatMedicalRepository.GetAllAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CertificatMedical>> GetCertificatMedical(int id)
        {
            var certificatMedical = await _certificatMedicalRepository.GetByIdAsync(id);
            if (certificatMedical == null)
                return NotFound();
            return Ok(certificatMedical);
        }

        [HttpPost]
        public async Task<ActionResult> CreateCertificatMedical(CertificatMedical certificatMedical)
        {
            await _certificatMedicalRepository.AddAsync(certificatMedical);
            return CreatedAtAction(nameof(GetCertificatMedical), new { id = certificatMedical.ID }, certificatMedical);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCertificatMedical(int id, CertificatMedical certificatMedical)
        {
            if (id != certificatMedical.ID)
                return BadRequest();

            await _certificatMedicalRepository.UpdateAsync(certificatMedical);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCertificatMedical(int id)
        {
            await _certificatMedicalRepository.DeleteAsync(id);
            return NoContent();
        }
    }
}
