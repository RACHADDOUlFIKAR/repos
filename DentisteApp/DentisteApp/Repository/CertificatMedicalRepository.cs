using DentisteApp.IRepositories;
using DentisteApp.Models.Entities;
using GestionBudget.Data;
using Microsoft.EntityFrameworkCore;


namespace DentisteApp.Repositories
{
    public class CertificatMedicalRepository : ICertificatMedicalRepository
    {
        private readonly AppDbContext _context;

        public CertificatMedicalRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<CertificatMedical>> GetAllAsync()
        {
            return await _context.CertificatsMedicaux
                 .Include(a => a.Patient)
                 .ToListAsync();
        }

        public async Task<CertificatMedical> GetByIdAsync(int id)
        {
            return await _context.CertificatsMedicaux.FindAsync(id);
        }

        public async Task AddAsync(CertificatMedical certificatMedical)
        {
            var patientExists = await _context.Patients.AnyAsync(p => p.ID == certificatMedical.PatientID);
            if (!patientExists)
            {
                throw new ArgumentException("Le patient spécifié n'existe pas.");
            }
            await _context.CertificatsMedicaux.AddAsync(certificatMedical);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(CertificatMedical certificatMedical)
        {
            _context.CertificatsMedicaux.Update(certificatMedical);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var certificatMedical = await GetByIdAsync(id);
            if (certificatMedical != null)
            {
                _context.CertificatsMedicaux.Remove(certificatMedical);
                await _context.SaveChangesAsync();
            }
        }
    }
}
