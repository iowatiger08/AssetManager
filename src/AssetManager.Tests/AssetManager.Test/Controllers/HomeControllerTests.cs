using System;
using NUnit.Framework;

using AssetManager.Controllers;


namespace AssetManager.Tests
{
    
    public class HomeControllerTests
    {
        private HomeController homeController;

        [Test]
        public void TestHomeIndex()
        {
            Assert.NotNull(homeController.Index());
        }
        [Test]
        public void TestHomeAbout()
        {
            Assert.NotNull(homeController.About());
        }
        [Test]
        public void TestHomeContact()
        {
            Assert.NotNull(homeController.Contact());
        }

        [Test]
        public void TestHomeError()
        {
            Assert.NotNull(homeController.Error());
        }
    }
}
