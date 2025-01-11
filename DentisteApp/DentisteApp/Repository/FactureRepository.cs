using DentisteApp.IRepositories;
using DentisteApp.Models.Entities;
using GestionBudget.Data;
using Microsoft.EntityFrameworkCore;


namespace DentisteApp.Repositories
{
    public class FactureRepository : IFactureRepository
    {
        private readonly AppDbContext _context;

        public FactureRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Facture>> GetAllAsync()
        {
            return await _context.Factures
                .Include(a => a.Patient)
                .ToListAsync();
        }

        public async Task<Facture> GetByIdAsync(int id)
        {
            return await _context.Factures.FindAsync(id);
        }

        public async Task AddAsync(Facture facture)
        {
            var patientExists = await _context.Patients.AnyAsync(p => p.ID == facture.PatientID);
            if (!patientExists)
            {
                throw new ArgumentException("Le patient spécifié n'existe pas.");
            }
            await _context.Factures.AddAsync(facture);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Facture facture)
        {
            _context.Factures.Update(facture);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var facture = await GetByIdAsync(id);
            if (facture != null)
            {
                _context.Factures.Remove(facture);
                await _context.SaveChangesAsync();
            }
        }
    }
}
