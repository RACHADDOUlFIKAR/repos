using DentisteApp.IRepositories;
using DentisteApp.Models.Entities;
using GestionBudget.Data;
using Microsoft.EntityFrameworkCore;


namespace DentisteApp.Repositories
{
    public class PaiementRepository : IPaiementRepository
    {
        private readonly AppDbContext _context;

        public PaiementRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Paiement>> GetAllAsync()
        {
            return await _context.Paiements
                .Include(p => p.Acte)    // Inclure les détails de l'Acte
               
                .ToListAsync();
        }


        public async Task<Paiement> GetByIdAsync(int id)
        {
            return await _context.Paiements.FindAsync(id);
        }

        public async Task AddAsync(Paiement paiement)
        {
            try
            {
               

                // Vérifier si l'acte existe
                var acteExists = await _context.Actes.AnyAsync(a => a.ID == paiement.ActeID);
                if (!acteExists)
                {
                    throw new ArgumentException("L'acte spécifié n'existe pas.");
                }

                // Ajouter le paiement
                await _context.Paiements.AddAsync(paiement);
                await _context.SaveChangesAsync();
            }
            catch (ArgumentException ex)
            {
                // Gérer les erreurs de validation
                throw new Exception($"Erreur lors de l'ajout du paiement : {ex.Message}");
            }
            catch (Exception ex)
            {
                // Gérer d'autres types d'erreurs
                throw new Exception($"Erreur inattendue : {ex.Message}");
            }
        }


        public async Task UpdateAsync(Paiement paiement)
        {
            _context.Paiements.Update(paiement);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var paiement = await GetByIdAsync(id);
            if (paiement != null)
            {
                _context.Paiements.Remove(paiement);
                await _context.SaveChangesAsync();
            }
        }
    }
}
