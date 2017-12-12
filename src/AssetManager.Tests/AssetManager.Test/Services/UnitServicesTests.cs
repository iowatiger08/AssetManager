using System;
using System.Collections.Generic;
using System.Text;

using NUnit.Framework;
using Moq;
using AssetManager.Models;
using AssetManager.Entity;

namespace AssetManager.Services
{
    public class UnitServicesTests
    {
        private UnitService unitService;
        private Mock<ManagerDbContext> mockDbContext;
        [SetUp]
        public void Init()
        {
            unitService = new UnitService(mockDbContext.Object);
            //unitService._context = mockDbContext.Object;
        }

        [Test]
        public void TestGetUnitById()
        {
            Unit aUnit = new Unit()
            {
                UNIT_ID = 1001
            };
            var result = unitService.GetById(aUnit.UNIT_ID);

            Assert.That(result.Result.UNIT_ID, Is.EqualTo(aUnit.UNIT_ID));
            //mockDbContext.Setup(r =>r.FindAsync(aUnit.GetType, u ))
        }

        [Test]
        public void TestGetAllUnit()
        {
            Unit aUnit = new Unit()
            {
                UNIT_ID = 1001
            };

            var result = unitService.GetList();

            Assert.That(result.Result.Contains(aUnit), Is.True);
        }

        [Test]
        public void TestUpdateUnit()
        {
            Unit aUnit = new Unit()
            {
                UNIT_ID = 1001,
                UNIT_CODE ="R1001"
            };

            var result = unitService.PushUpdate(aUnit);

            Assert.That(result.Result.UNIT_CODE, Is.EqualTo(aUnit.UNIT_CODE));
        }

        [Test]
        public void TestSaveOrUpdateUnit()
        {
            Unit aUnit = new Unit()
            {
                UNIT_ID = 1001,
                UNIT_CODE = "R1001"
            };

            var result = unitService.SaveOrUpdate(aUnit);

            Assert.That(result.Result.UNIT_CODE, Is.EqualTo(aUnit.UNIT_CODE));
        }

        [Test]
        public void TestRemoveUnit()
        {
            Unit aUnit = new Unit()
            {
                UNIT_ID = 1001,
                UNIT_CODE = "R1001",
                ACTIVE_FLAG=0
            };

            var result = unitService.RemoveItem(aUnit);

            Assert.That(result.Result.ACTIVE_FLAG, Is.EqualTo(aUnit.ACTIVE_FLAG));
        }
    }
}
