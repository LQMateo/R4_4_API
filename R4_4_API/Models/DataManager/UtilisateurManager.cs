using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using R4_4_API.Models.EntityFramework;
using R4_4_API.Models.Repository;

namespace R4_4_API.Models.DataManager
{
    public class UtilisateurManager : IDataRepository<Utilisateur>
    {
        readonly LequmaContext? filmsDbContext;

        public UtilisateurManager() { }
        public UtilisateurManager(LequmaContext context)
        {
            filmsDbContext = context;
        }

        public async Task<ActionResult<IEnumerable<Utilisateur>>> GetAllAsync()
        {
            return await filmsDbContext.Utilisateurs.ToListAsync();
        }
        public async Task<ActionResult<Utilisateur>> GetByIdAsync(int id)
        {
            return await filmsDbContext.Utilisateurs.FirstOrDefaultAsync(u => u.Id == id);
        }
        public async Task<ActionResult<Utilisateur>> GetByStringAsync(string mail)
        {
            return await filmsDbContext.Utilisateurs.FirstOrDefaultAsync(u => u.Mail.ToUpper() == mail.ToUpper());
        }
        public async Task AddAsync(Utilisateur entity)
        {
            filmsDbContext.Utilisateurs.AddAsync(entity);
            filmsDbContext.SaveChangesAsync();
        }
        public async Task UpdateAsync(Utilisateur utilisateur, Utilisateur entity)
        {            
            filmsDbContext.Entry(utilisateur).State = EntityState.Modified;
            utilisateur.Id = entity.Id;
            utilisateur.Nom = entity.Nom;
            utilisateur.Prenom = entity.Prenom;
            utilisateur.Mail = entity.Mail;
            utilisateur.Rue = entity.Rue;
            utilisateur.Cp = entity.Cp;
            utilisateur.Ville = entity.Ville;
            utilisateur.Pays = entity.Pays;
            utilisateur.Latitude = entity.Latitude;
            utilisateur.Longitude = entity.Longitude;
            utilisateur.Pwd = entity.Pwd;
            utilisateur.Mobile = entity.Mobile;
            utilisateur.NotationUtilisateur = entity.NotationUtilisateur;
            filmsDbContext.SaveChanges();
        }
        public async Task DeleteAsync(Utilisateur utilisateur)
        {
            filmsDbContext.Utilisateurs.Remove(utilisateur);
            filmsDbContext.SaveChanges();
        }
    }
}
