using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using Moq;

using AssetManager.Services;
using AssetManager.Entity;
using System.Threading.Tasks;
using System.Linq;

namespace AssetManager.Controllers
{
    public class UnitControllerTests
    {
        private UnitController unitController;
        //private Mock<IWebServices<UnitProfile>> mockUnitService;
        private Mock<IWebServices<UnitProfile>> mockUnitProfileService;
        private Mock<AuthenticationService> mockAuthenticationService;


        [SetUp]
        public void Init()
        {
            mockAuthenticationService = new Mock<AuthenticationService>();
            mockUnitProfileService = new Mock<IWebServices<UnitProfile>>();
            //unitController = new UnitController();
        }

        List<UnitProfile> BuildListOfUnitProfiles()
        {

            List<UnitProfile> listOfUnitProfiles = new List<UnitProfile>();
            Unit aUnit = new Unit()
            {
                UNIT_ID = 1001
            };

            listOfUnitProfiles= AddUnitToListOfUnitProfiles(aUnit, listOfUnitProfiles);

            Unit aUnit2 = new Unit()
            {
                UNIT_ID = 2001
            };

            listOfUnitProfiles = AddUnitToListOfUnitProfiles(aUnit2, listOfUnitProfiles);
            return listOfUnitProfiles;
        }

        List<UnitProfile> AddUnitToListOfUnitProfiles(Unit aUnit, List<UnitProfile> listOfUnitProfiles)
        {
            if (listOfUnitProfiles == null || !listOfUnitProfiles.Any())
            {
                listOfUnitProfiles = new List<UnitProfile>();
            }
            UnitProfile aProfile = new UnitProfile();
            aProfile.Unit = aUnit;
            listOfUnitProfiles.Add(aProfile);
            return listOfUnitProfiles;
        }
        /**
         * as a user I send a request to view List of units
         * */
        [Test]
        public void TestRetrieveUnitList()
        {
            List<Unit> listOfUnits = new List<Unit>();
            List<UnitProfile> listOfUnitProfiles = BuildListOfUnitProfiles();

            mockUnitProfileService.Setup(s => s.GetList()).Returns(Task.FromResult(BuildListOfUnitProfiles()));
            mockAuthenticationService.Setup(s => s.UserHasPrivs(It.IsAny<User>())).Returns(true);
            unitController = new UnitController(mockUnitProfileService.Object);
            var result = unitController.GetAll();
            var list = result.Result;
            Assert.That(list.Count, Is.EqualTo(2));
            //Assert.That(list.Find(i=>i.Id==aUnit.Id).Id, Is.EqualTo(aUnit.Id));
        }

        /**
         * as a user I send a request to retrieve a Unit by known ID
         */
        [Test]
        public void TestRetrieveaUnitById()
        {
            Unit aUnit = new Unit()
            {
                UNIT_ID = 1001
            };
            UnitProfile unitProfile = new UnitProfile()
            {
                Unit = aUnit
            };

            mockUnitProfileService.Setup(s => s.GetById(It.IsAny<long>())).Returns(Task.FromResult(unitProfile));
            mockAuthenticationService.Setup(s => s.UserHasPrivs(It.IsAny<User>())).Returns(true);
            unitController = new UnitController(mockUnitProfileService.Object);
            
            var result = unitController.Get(aUnit.UNIT_ID);
            var entity = result.Result;
            Assert.That(entity.Unit.UNIT_ID, Is.EqualTo(aUnit.UNIT_ID));
        }
        /**
         * as a user I send a request to retrieve a Unit and have credentials to view 
         */
        [Test]
        public void TestUserHasRightstoRetrieveUnits()
        {
            Unit aUnit = new Unit()
            {
                UNIT_ID = 1001
            };
            UnitProfile unitProfile = new UnitProfile()
            {
                Unit = aUnit
            };

            mockUnitProfileService.Setup(s => s.GetById(It.IsAny<long>())).Returns(Task.FromResult(unitProfile));
            mockAuthenticationService.Setup(s => s.UserHasPrivs(It.IsAny<User>())).Returns(true);

            unitController = new UnitController(mockUnitProfileService.Object);

            var result = unitController.Get(aUnit.UNIT_ID);
            var entity = result.Result;
            Assert.That(entity.Unit.UNIT_ID, Is.EqualTo(aUnit.UNIT_ID));
        }

        /**
         * as a user I send a request to retrieve a Unit but do not have credentials to view 
         */
        [Test]
        public void TestUserHasNoRightstoRetrieveUnits()
        {
            Unit aUnit = new Unit()
            {
                UNIT_ID = 1001
            };
            UnitProfile unitProfile = new UnitProfile()
            {
                Unit = aUnit
            };
            mockUnitProfileService.Setup(s => s.GetById(It.IsAny<long>())).Returns(Task.FromResult(unitProfile));
            mockAuthenticationService.Setup(s => s.UserHasPrivs(It.IsAny<User>())).Returns(false);

            unitController = new UnitController(mockUnitProfileService.Object);

            Assert.ThrowsAsync<UnauthorizedAccessException>(async () => await unitController.GetAll());
        }
        /**
         * as a user I send a request to update a Unit and does nt have credentials to update 
         */
        [Test]
        public void TestUserHasNoPrivstoUpdateUnits()
        {
            Unit aUnit = new Unit()
            {
                UNIT_ID = 1001,
                UNIT_CODE ="R10001"
            };
            UnitProfile unitProfile = new UnitProfile()
            {
                Unit = aUnit
            };

            mockUnitProfileService.Setup(s => s.GetById(It.IsAny<long>())).Returns(Task.FromResult(unitProfile));
            mockAuthenticationService.Setup(s => s.UserHasPrivs(It.IsAny<User>())).Returns(false);

            unitController = new UnitController(mockUnitProfileService.Object);

            Assert.ThrowsAsync<UnauthorizedAccessException>(async () => await unitController.Post(unitProfile));
        }
        /**
         * as a user I send a request to update a Unit and does have credentials to update 
         */
        [Test]
        public void TestUserhasPrivsToUpdateUnit()
        {
            Unit aUnit = new Unit()
            {
                UNIT_ID = 1001,
                UNIT_CODE = "R10001"
            };
            UnitProfile unitProfile = new UnitProfile()
            {
                Unit = aUnit
            };
            mockUnitProfileService.Setup(s => s.SaveOrUpdate(It.IsAny<UnitProfile>())).Returns(Task.FromResult(unitProfile));
            mockAuthenticationService.Setup(s => s.UserHasPrivs(It.IsAny<User>())).Returns(true);

            unitController = new UnitController(mockUnitProfileService.Object);

            //var result = unitController.Post(unitProfile);

            Assert.DoesNotThrowAsync(async () => await unitController.Post(unitProfile));
        }
        /**
         * as a user I send a request to update a Unit and gets response with updated information 
         */
        [Test]
        public void TestUserUpdateUnitWithUpdateResponse()
        {
            Unit aUnit = new Unit()
            {
                UNIT_ID = 1001,
                UNIT_CODE = "R10001"
            };
            UnitProfile unitProfile = new UnitProfile()
            {
                Unit = aUnit
            };
            mockUnitProfileService.Setup(s => s.SaveOrUpdate(It.IsAny<UnitProfile>())).Returns(Task.FromResult(unitProfile));
            mockAuthenticationService.Setup(s => s.UserHasPrivs(It.IsAny<User>())).Returns(true);

            unitController = new UnitController(mockUnitProfileService.Object);

            var result = unitController.Post(unitProfile);
            var resultingProfile = result.Result;

            Assert.That(resultingProfile.Unit.UNIT_CODE, Is.EqualTo(aUnit.UNIT_CODE));
        }

        /**
         * as a user I send a request to update a Unit and does nt have credentials to update 
         */
        [Test]
        public void TestUserHasNoPrivstoDeactivateUnits()
        {
            Unit aUnit = new Unit()
            {
                UNIT_ID = 1001,
                UNIT_CODE = "R10001",
                ACTIVE_FLAG = 0
            };
            UnitProfile unitProfile = new UnitProfile()
            {
                Unit = aUnit
            };
            // mockUnitService.Setup(s => s.RemoveItem(It.IsAny<Unit>())).Returns(Task.FromResult(aUnit));
            mockAuthenticationService.Setup(s => s.UserHasPrivs(It.IsAny<User>())).Returns(false);

            unitController = new UnitController(mockUnitProfileService.Object);

            Assert.ThrowsAsync<UnauthorizedAccessException>(async () => await unitController.Post(unitProfile));
        }
        /**
         * as a user I send a request to update a Unit and does have credentials to update 
         */
        [Test]
        public void TestUserhasPrivsToDeactivateUnit()
        {
            Unit aUnit = new Unit()
            {
                UNIT_ID = 1001,
                UNIT_CODE = "R10001",
                ACTIVE_FLAG = 0
            };
            UnitProfile unitProfile = new UnitProfile()
            {
                Unit = aUnit
            };
            mockUnitProfileService.Setup(s => s.RemoveItem(It.IsAny<UnitProfile>())).Returns(Task.FromResult(unitProfile));
            mockAuthenticationService.Setup(s => s.UserHasPrivs(It.IsAny<User>())).Returns(true);

            unitController = new UnitController(mockUnitProfileService.Object);

            Assert.DoesNotThrowAsync(async () => await unitController.Post(unitProfile));
        }

        /**
         * as a user I send a request to update a Unit and gets response with unit deactivated 
         */
        [Test]
        public void TestUserUpdateUnitDeactivatedUpdateResponse()
        {
            Unit aUnit = new Unit()
            {
                UNIT_ID = 1001,
                UNIT_CODE = "R10001",
                ACTIVE_FLAG = 0
            };
            UnitProfile unitProfile = new UnitProfile()
            {
                Unit = aUnit
            };
            mockUnitProfileService.Setup(s => s.RemoveItem(It.IsAny<UnitProfile>())).Returns(Task.FromResult(unitProfile));
            mockAuthenticationService.Setup(s => s.UserHasPrivs(It.IsAny<User>())).Returns(true);

            unitController = new UnitController(mockUnitProfileService.Object);

            var result =  unitController.Post(unitProfile);
            var resultingProfile = result.Result;

            Assert.That(resultingProfile.Unit.ACTIVE_FLAG, Is.EqualTo(0));
        }
    }
}
