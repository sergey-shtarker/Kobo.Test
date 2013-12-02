using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Kobo.Test.MvcApplication;
using Kobo.Test.MvcApplication.Controllers;
using Moq;
using Kobo.Test.MvcApplication.Contracts;
using Kobo.Test.MvcApplication.Models;

namespace Kobo.Test.MvcApplication.Tests.Controllers
{
    [TestClass]
    public class PersonControllerTest
    {
        [TestMethod]
        public void PersonController_Index()
        {
            // Arrange
            IList<PersonItemModel> list = new List<PersonItemModel>();
            list.Add(new PersonItemModel { Id = 1, FirstName = "FirstName", LastName = "LastName" });

            var mockPersonModelService = new Mock<IPersonModelService>();
            mockPersonModelService.Setup(service => service.GetPersonItemModelList()).Returns(list);

            // Act
            PersonController controller = new PersonController(mockPersonModelService.Object);
            ViewResult viewResult = (ViewResult) controller.Index();

            // Assert
            Assert.IsNotNull(viewResult);
            Assert.IsNotNull(viewResult.Model);
            Assert.AreEqual(1, ((IList<PersonItemModel>)viewResult.Model).Count);
        }
    }
}
