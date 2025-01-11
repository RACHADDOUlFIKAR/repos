using DentisteApp.IRepositories;
using DentisteApp.Models.Entities;
using GestionBudget.Data;
using Microsoft.EntityFrameworkCore;


namespace DentisteApp.Repositories
{
    public class OrdonnanceRepository : IOrdonnanceRepository
    {
        private readonly AppDbContext _context;

        public OrdonnanceRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Ordonnance>> GetAllAsync()
        {
            return await _context.Ordonnances
                 .Include(a => a.Patient)
                 .ToListAsync();
        }

        public async Task<Ordonnance> GetByIdAsync(int id)
        {
            return await _context.Ordonnances.FindAsync(id);
        }

        public async Task AddAsync(Ordonnance ordonnance)
        {
            var patientExists = await _context.Patients.AnyAsync(p => p.ID == ordonnance.PatientID);
            if (!patientExists)
            {
                throw new ArgumentException("Le patient spécifié n'existe pas.");
            }
            await _context.Ordonnances.AddAsync(ordonnance);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Ordonnance ordonnance)
        {
            _context.Ordonnances.Update(ordonnance);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var ordonnance = await GetByIdAsync(id);
            if (ordonnance != null)
            {
                _context.Ordonnances.Remove(ordonnance);
                await _context.SaveChangesAsync();
            }
        }
    }
}
