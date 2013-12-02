using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Kobo.Test.DataContracts;
using Kobo.Test.Contracts;
using Kobo.Test.Services;
using Moq;
using System.ServiceModel;

namespace Kobo.Test.ServicesTest
{
    [TestClass]
    public class PersonServiceTest
    {
        [TestMethod]
        public void PersonService_Create_Ok()
        {
            // ARRANGE
            long id = 10;
            Person person = new Person();

            var mockBusinessLogic = new Mock<IPersonBusinessLogic>();
            mockBusinessLogic.Setup(bl => bl.Create(person)).Returns(id);

            // ACT
            IPersonService personService = new PersonService(mockBusinessLogic.Object);
            var actual = personService.Create(person);

            // ASSERT
            Assert.IsNotNull(actual);
            mockBusinessLogic.Verify(bl => bl.Create(person), Times.Once(), "Create was not called!");
        }

        [TestMethod]
        [ExpectedException(typeof(FaultException<Exception>))]
        public void PersonService_Create_Exception()
        {
            // ARRANGE
            Exception e = new Exception();
            Person person = new Person();

            var mockBusinessLogic = new Mock<IPersonBusinessLogic>();
            mockBusinessLogic.Setup(bl => bl.Create(person)).Throws(e);

            // ACT
            IPersonService personService = new PersonService(mockBusinessLogic.Object);
            var actual = personService.Create(person);

            // ASSERT
            mockBusinessLogic.Verify(bl => bl.Create(person), Times.Once(), "Create was not called!");
        }
    }
}
