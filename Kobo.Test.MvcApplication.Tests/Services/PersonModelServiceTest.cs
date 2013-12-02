using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Kobo.Test.MvcApplication.Contracts;
using Kobo.Test.MvcApplication.Services;
using Kobo.Test.MvcApplication.Models;
using System.Collections.Generic;
using Moq;
using Kobo.Test.MvcApplication.ServiceReference;

namespace Kobo.Test.MvcApplication.Tests.Services
{
    [TestClass]
    public class PersonModelServiceTest
    {
        [TestMethod]
        public void PersonModelService_GetPersonListModel()
        {
            // ARRANGE
            List<Person> personList = new List<Person>();

            IList<PersonItemModel> personItemModelList = new List<PersonItemModel>();

            var mockPersonService = new Mock<IPersonService>();
            mockPersonService.Setup(service => service.ReadAll()).Returns(personList);

            var mockPersonModelBuilder = new Mock<IPersonModelBuilder>();
            mockPersonModelBuilder.Setup(builder => builder.BuildPersonListModel(personList)).Returns(personItemModelList);

            // ACT
            IPersonModelService personModelService = new PersonModelService(mockPersonService.Object, mockPersonModelBuilder.Object);
            IList<PersonItemModel> actual = personModelService.GetPersonItemModelList();

            // ASSERT
            Assert.IsNotNull(actual);
        }
    }
}
