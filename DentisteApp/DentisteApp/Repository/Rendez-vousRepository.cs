using DentisteApp.IRepositories;
using DentisteApp.Models.Entities;
using GestionBudget.Data;
using Microsoft.EntityFrameworkCore;

namespace DentisteApp.Repository
{
    public class Rendez_vousRepository : IRendez_vousRepository
    {
        private readonly AppDbContext _context;

        public Rendez_vousRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Rendez_vous entity)
        {
            await _context.Rendez_vous.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await GetByIdAsync(id); // Attendre la tâche pour obtenir l'objet
            if (entity != null)
            {
                _context.Rendez_vous.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Rendez_vous>> GetAllAsync()
        {
            return await _context.Rendez_vous.Include(a => a.Patient)
                .ToListAsync(); 
        }

        public async Task<Rendez_vous?> GetByIdAsync(int id) // Utiliser le type nullable
        {
            return await _context.Rendez_vous.FindAsync(id);
        }

        public Task UpdateAsync(Rendez_vous entity)
        {
            _context.Rendez_vous.Update(entity);
            return _context.SaveChangesAsync();
        }
    }
}
