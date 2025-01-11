using DentisteApp.IRepositories;
using DentisteApp.Models.Entities;
using GestionBudget.Data;
using Microsoft.EntityFrameworkCore;

namespace DentisteApp.Repositories
{
    public class ActeRepository : IActeRepository
    {
        private readonly AppDbContext _context;

        public ActeRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Acte>> GetAllAsync()
        {
            // Inclure les informations sur le patient
            return await _context.Actes
                .Include(a => a.Patient)
                .ToListAsync();
        }

        public async Task<Acte> GetByIdAsync(int id)
        {
            // Charger l'acte par ID avec le patient associé
            return await _context.Actes
                .Include(a => a.Patient)
                .FirstOrDefaultAsync(a => a.ID == id);
        }

        public async Task AddAsync(Acte acte)
        {
            // Vérifier si le patient existe dans la base de données
            var patientExists = await _context.Patients.AnyAsync(p => p.ID == acte.PatientID);
            if (!patientExists)
            {
                throw new ArgumentException("Le patient spécifié n'existe pas.");
            }

            await _context.Actes.AddAsync(acte);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Acte acte)
        {
            // Vérifier si le patient existe dans la base de données
            var patientExists = await _context.Patients.AnyAsync(p => p.ID == acte.PatientID);
            if (!patientExists)
            {
                throw new ArgumentException("Le patient spécifié n'existe pas.");
            }

            _context.Actes.Update(acte);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var acte = await GetByIdAsync(id);
            if (acte != null)
            {
                _context.Actes.Remove(acte);
                await _context.SaveChangesAsync();
            }
        }
    }
}
