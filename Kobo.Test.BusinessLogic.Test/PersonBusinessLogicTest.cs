using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Kobo.Test.Contracts;
using Moq;
using Kobo.Test.DataContracts;

namespace Kobo.Test.BusinessLogic.Test
{
    [TestClass]
    public class PersonBusinessLogicTest
    {
        [TestMethod]
        public void PersonBusinessLogic_Create()
        {
            // ARRANGE
            long id = 10;
            Person person = new Person();

            var mockPersonRepository = new Mock<IPersonRepository>();
            mockPersonRepository.Setup(repo => repo.Create(person)).Returns(id);

            // ACT
            IPersonBusinessLogic personBusinessLogic = new PersonBusinessLogic(mockPersonRepository.Object);
            var actual = personBusinessLogic.Create(person);

            // ASSERT
            Assert.IsNotNull(actual);
            mockPersonRepository.Verify(repo => repo.Create(person), Times.Once(), "Create was not called!");
        }
    }
}
