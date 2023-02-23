using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
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
        public void GetUtilisateurById_ExistingIdPassed_ReturnsRightItem_AvecMoq()
        {
            // Arrange
            Utilisateur user = new Utilisateur
            {
                Id = 1,
                Nom = "Calida",
                Prenom = "Lilley",
                Mobile = "0653930778",
                Mail = "clilleymd@last.fm",
                Pwd = "Toto12345678!",
                Rue = "Impasse des bergeronnettes",
                Cp = "74200",
                Ville = "Allinges",
                Pays = "France",
                Latitude = 46.344795F,
                Longitude = 6.4885845F
            };
            var mockRepository = new Mock<IDataRepository<Utilisateur>>();
            mockRepository.Setup(x => x.GetByIdAsync(1).Result).Returns(user);
            var userController = new UtilisateursController(mockRepository.Object);
            // Act
            var actionResult = userController.GetUtilisateurById(1).Result;
            // Assert
            Assert.IsNotNull(actionResult);
            Assert.IsNotNull(actionResult.Value);
            Assert.AreEqual(user, actionResult.Value as Utilisateur);
        }

        [TestMethod]
        public void GetUtilisateurById_UnknownIdPassed_ReturnsNotFoundResult_AvecMoq()
        {
            var mockRepository = new Mock<IDataRepository<Utilisateur>>();
            var userController = new UtilisateursController(mockRepository.Object);
            // Act
            var actionResult = userController.GetUtilisateurById(0).Result;
            // Assert
            Assert.IsInstanceOfType(actionResult.Result, typeof(NotFoundResult));
        }

        [TestMethod()]
        public void GetUtilisateurByEmail_ExistingIdPassed_ReturnsRightItem_AvecMoq()
        {
            // Arrange
            Utilisateur user = new Utilisateur
            {
                Id = 1,
                Nom = "Calida",
                Prenom = "Lilley",
                Mobile = "0653930778",
                Mail = "clilleymd@last.fm",
                Pwd = "Toto12345678!",
                Rue = "Impasse des bergeronnettes",
                Cp = "74200",
                Ville = "Allinges",
                Pays = "France",
                Latitude = 46.344795F,
                Longitude = 6.4885845F
            };
            var mockRepository = new Mock<IDataRepository<Utilisateur>>();
            mockRepository.Setup(x => x.GetByStringAsync("clilleymd@last.fm").Result).Returns(user);
            var userController = new UtilisateursController(mockRepository.Object);
            // Act
            var actionResult = userController.GetUtilisateurByEmail("clilleymd@last.fm").Result;
            // Assert
            Assert.IsNotNull(actionResult);
            Assert.IsNotNull(actionResult.Value);
            Assert.AreEqual(user, actionResult.Value as Utilisateur);
        }


        [TestMethod()]
        public async Task GetUtilisateurByEmailTestTrue()
        {
            ActionResult<Utilisateur> enume = await _controller.GetUtilisateurByEmail("clilleymd@last.fm");
            Assert.AreEqual(_context.Utilisateurs.Where(c => c.Mail == "clilleymd@last.fm").FirstOrDefault(), enume.Value);
        }

        [TestMethod()]
        public async Task PutUtilisateurTest()
        {
            // Arrange
            Utilisateur user = new Utilisateur
            {
                Id = 1,
                Nom = "Calida",
                Prenom = "Lilley",
                Mobile = "0653930778",
                Mail = "clilleymd@last.fm",
                Pwd = "Toto12345678!",
                Rue = "Impasse des bergeronnettes",
                Cp = "74200",
                Ville = "Allinges",
                Pays = "France",
                Latitude = 46.344795F,
                Longitude = 6.4885845F
            };

            var mockRepository = new Mock<IDataRepository<Utilisateur>>();
            mockRepository.Setup(x => x.GetByIdAsync(user.Id).Result).Returns(user);
            var userController = new UtilisateursController(mockRepository.Object);

            // Act
            user.Nom = "Nouveau";
            var actionResult = await userController.PutUtilisateur(user.Id, user);
            var actionResultuserUpdated = userController.GetUtilisateurById(user.Id).Result;

            // Assert
            Assert.IsInstanceOfType(actionResult, typeof(ActionResult<Utilisateur>), "Pas un ActionResult<Utilisateur>");


            Assert.IsInstanceOfType(actionResultuserUpdated.Result, typeof(OkObjectResult), "Pas un OkObjectResult");
            var result = actionResultuserUpdated.Result as OkObjectResult;

            Assert.IsInstanceOfType(result.Value, typeof(Utilisateur), "Pas un Utilisateur");
            Assert.AreEqual(user, (Utilisateur)actionResultuserUpdated.Value, "Utilisateurs pas identiques");
        }

        [TestMethod]
        public async Task Postutilisateur_ModelValidated_CreationOK()
        {
            // Arrange
            var mockRepository = new Mock<IDataRepository<Utilisateur>>();
            var userController = new UtilisateursController(mockRepository.Object);

            Utilisateur user = new Utilisateur
            {
                Nom = "POISSON",
                Prenom = "Pascal",
                Mobile = "1",
                Mail = "poisson@gmail.com",
                Pwd = "Toto12345678!",
                Rue = "Chemin de Bellevue",
                Cp = "74940",
                Ville = "Annecy-le-Vieux",
                Pays = "France",
                Latitude = null,
                Longitude = null
            };
            // Act
            var actionResult = userController.PostUtilisateur(user).Result;
            // Assert
            Assert.IsInstanceOfType(actionResult, typeof(ActionResult<Utilisateur>), "Pas un ActionResult<Utilisateur>");
            Assert.IsInstanceOfType(actionResult.Result, typeof(CreatedAtActionResult), "Pas un CreatedAtActionResult");
            var result = actionResult.Result as CreatedAtActionResult;
            Assert.IsInstanceOfType(result.Value, typeof(Utilisateur), "Pas un Utilisateur");
            user.Id = ((Utilisateur)result.Value).Id;
            Assert.AreEqual(user, (Utilisateur)result.Value, "Utilisateurs pas identiques");
        }


        [TestMethod]
        public void DeleteUtilisateurTest_AvecMoq()
        {
            // Arrange
            Utilisateur user = new Utilisateur
            {
                Id = 1,
                Nom = "Calida",
                Prenom = "Lilley",
                Mobile = "0653930778",
                Mail = "clilleymd@last.fm",
                Pwd = "Toto12345678!",
                Rue = "Impasse des bergeronnettes",
                Cp = "74200",
                Ville = "Allinges",
                Pays = "France",
                Latitude = 46.344795F,
                Longitude = 6.4885845F
            };
            var mockRepository = new Mock<IDataRepository<Utilisateur>>();
            mockRepository.Setup(x => x.GetByIdAsync(1).Result).Returns(user);
            var userController = new UtilisateursController(mockRepository.Object);
            // Act
            var actionResult = userController.DeleteUtilisateur(1).Result;
            // Assert
            Assert.IsInstanceOfType(actionResult, typeof(NoContentResult), "Pas un NoContentResult"); // Test du type de retour
        }





    }
}