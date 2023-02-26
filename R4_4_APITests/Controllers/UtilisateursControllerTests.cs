using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using R4_4_API.Controllers;
using R4_4_API.Models.DataManager;
using R4_4_API.Models.EntityFramework;
using R4_4_API.Models.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace R4_4_API.Controllers.Tests
{
    [TestClass()]
    public class UtilisateursControllerTests
    {
        private readonly LequmaContext _context;
        private readonly UtilisateursController _controller;
        private IDataRepository<Utilisateur> dataRepository;


        public UtilisateursControllerTests()
        {
            var builder = new DbContextOptionsBuilder<LequmaContext>().UseNpgsql("Server=51.83.36.122; port=5432; Database=lequma; uid=lequma; password=thrzJ1; SearchPath=r41_4;"); 
            _context = new LequmaContext(builder.Options);
            dataRepository = new UtilisateurManager(_context);
            _controller = new UtilisateursController(dataRepository);
        }

        [TestMethod()]
        public async Task GetUtilisateursTestAsync()
        {
            ActionResult<IEnumerable<Utilisateur>> users = await _controller.GetUtilisateur();            

            bool rep = true;
            for (int i = 0; i < _context.Utilisateurs.Count(); i++)            
                if (!(_context.Utilisateurs.ToList()[i] == users.Value.ToList()[i]))
                    rep = false;            
            Assert.AreEqual(true, rep, "La liste renvoyée n'est pas la bonne.");
        }


        [TestMethod()]
        public async Task GetUtilisateurByIdTestTrue()
        {
            ActionResult<Utilisateur> enume = await _controller.GetUtilisateurById(1);
            Assert.AreEqual(_context.Utilisateurs.Where(c => c.Id == 1).FirstOrDefault(), enume.Value);
        }

        [TestMethod()]
        public async Task GetUtilisateurByIdTestFalse()
        {
            ActionResult<Utilisateur> enume = await _controller.GetUtilisateurById(1);
            Assert.AreNotEqual(_context.Utilisateurs.Where(c => c.Id == 2).FirstOrDefault(), enume.Value);
        }

        [TestMethod()]
        public async Task GetUtilisateurByEmailTestTrue()
        {
            ActionResult<Utilisateur> enume = await _controller.GetUtilisateurByEmail("clilleymd@last.fm");
            Assert.AreEqual(_context.Utilisateurs.Where(c => c.Mail == "clilleymd@last.fm").FirstOrDefault(), enume.Value);
        }
        [TestMethod()]
        public async Task GetUtilisateurByEmailTestFalse()
        {
            ActionResult<Utilisateur> enume = await _controller.GetUtilisateurByEmail("clilleymd@last.fm");
            Assert.AreNotEqual(_context.Utilisateurs.Where(c => c.Mail == "clilleymd@las1.fm").FirstOrDefault(), enume.Value);
        }

        [TestMethod()]
        public async Task PutUtilisateurTest()
        {
            Utilisateur user = _context.Utilisateurs.Find(1);
            String newName = user.Nom + "test";
            user.Nom = newName;
            _controller.PutUtilisateur(1, user);

            Utilisateur newUser = _context.Utilisateurs.Find(1);
            Assert.AreEqual(newName, newUser.Nom);
        }

        [TestMethod]
        public async Task Postutilisateur_ModelValidated_CreationOK()
        {
            Random rnd = new Random();
            int chiffre = rnd.Next(1, 1000000000);

            Utilisateur userAtester = new Utilisateur()
            {
                Nom = "MACHIN",
                Prenom = "Luc",
                Mobile = "0606070809",
                Mail = "machin" + chiffre + "@gmail.com",
                Pwd = "Toto1234!",
                Rue = "Chemin de Bellevue",
                Cp = "74940",
                Ville = "Annecy-le-Vieux",
                Pays = "France",
                Latitude = null,
                Longitude = null
            };
            // Act
            var result = _controller.PostUtilisateur(userAtester).Result;
            Utilisateur? userRecupere = _context.Utilisateurs.Where(u => u.Mail.ToUpper() == userAtester.Mail.ToUpper()).FirstOrDefault();

            userAtester.Id = userRecupere.Id;
            Assert.AreEqual(userRecupere, userAtester, "Utilisateurs pas identiques");
        }

        [TestMethod()]
        public async Task DeleteUtilisateurTest()
        {
            // Arrange
            Random rnd = new Random();
            int chiffre = rnd.Next(1, 1000000000);

            Utilisateur userAtester = new Utilisateur()
            {
                Nom = "MACHIN",
                Prenom = "Luc",
                Mobile = "0606070809",
                Mail = "machin" + chiffre + "@gmail.com",
                Pwd = "Toto1234!",
                Rue = "Chemin de Bellevue",
                Cp = "74940",
                Ville = "Annecy-le-Vieux",
                Pays = "France",
                Latitude = null,
                Longitude = null
            };

            EntityEntry<Utilisateur> user = _context.Utilisateurs.Add(userAtester);
            await _context.SaveChangesAsync();

            await _controller.DeleteUtilisateur(user.Entity.Id);
            Utilisateur trouver = _context.Utilisateurs.Find(user.Entity.Id);
            Assert.IsNull(trouver);

        }
    }
}