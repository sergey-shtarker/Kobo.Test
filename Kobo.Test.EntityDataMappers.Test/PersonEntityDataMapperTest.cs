using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Kobo.Test.Entities.Models;
using System.Collections.Generic;
using Kobo.Test.Contracts;
using Kobo.Test.DataContracts;

namespace Kobo.Test.EntityDataMappers.Test
{
    [TestClass]
    public class PersonEntityDataMapperTest
    {
        [TestMethod]
        public void PersonEntityDataMapper_MapPersonEntityToPersonData()
        {
            // ARRANGE
            int expectedId = 10;
            string expectedFirstName = "FirstName";
            string expectedLastName = "LastName";
            DateTime? expectedBirthday = new DateTime(2013, 12, 1);
            string expectedEmail = "expectedEmail";
            string expectedTelephone = "Telephone";
            string expectedContactManager = "ContactManager";

            Entities.Models.Person entity = new Entities.Models.Person { Id = expectedId, FirstName = expectedFirstName, LastName = expectedLastName };
            entity.Customer = new Entities.Models.Customer { Birthday = expectedBirthday, Email = expectedEmail };
            entity.Supplier = new Entities.Models.Supplier { Telephone = expectedTelephone, ContactManager = expectedContactManager };

            // ACT
            IPersonEntityDataMapper map = new PersonEntityDataMapper();
            var actual = map.MapPersonEntityToPersonData(entity);

            // ASSERT
            Assert.IsNotNull(actual);
            Assert.AreEqual(expectedId, actual.Id);
            Assert.AreEqual(expectedFirstName, actual.FirstName);
            Assert.AreEqual(expectedLastName, actual.LastName);

            Assert.IsNotNull(actual.Customer);
            Assert.AreEqual(expectedBirthday, actual.Customer.Birthday);
            Assert.AreEqual(expectedEmail, actual.Customer.Email);

            Assert.IsNotNull(actual.Supplier);
            Assert.AreEqual(expectedTelephone, actual.Supplier.Telephone);
            Assert.AreEqual(expectedContactManager, actual.Supplier.ContactManager);
        }

        [TestMethod]
        public void PersonEntityDataMapper_MapPersonEntityToPersonData_nullCustomerAndSupplier()
        {
            // ARRANGE
            int expectedId = 10;
            string expectedFirstName = "FirstName";
            string expectedLastName = "LastName";
  
            Entities.Models.Person entity = new Entities.Models.Person { Id = expectedId, FirstName = expectedFirstName, LastName = expectedLastName };
 
            // ACT
            IPersonEntityDataMapper map = new PersonEntityDataMapper();
            var actual = map.MapPersonEntityToPersonData(entity);

            // ASSERT
            Assert.IsNotNull(actual);
            Assert.AreEqual(expectedId, actual.Id);
            Assert.AreEqual(expectedFirstName, actual.FirstName);
            Assert.AreEqual(expectedLastName, actual.LastName);

            Assert.IsNull(actual.Customer);
            Assert.IsNull(actual.Supplier);
         }

        [TestMethod]
        public void PersonEntityDataMapper_MapPersonDataToPersonEntity()
        {
            //// ARRANGE
            int expectedId = 10;
            string expectedFirstName = "FirstName";
            string expectedLastName = "LastName";
            DateTime? expectedBirthday = new DateTime(2013, 12, 1);
            string expectedEmail = "expectedEmail";
            string expectedTelephone = "Telephone";
            string expectedContactManager = "ContactManager";

            DataContracts.Person data = new DataContracts.Person { Id = expectedId, FirstName = expectedFirstName, LastName = expectedLastName };
            data.Customer = new DataContracts.Customer { Birthday = expectedBirthday, Email = expectedEmail };
            data.Supplier = new DataContracts.Supplier { Telephone = expectedTelephone, ContactManager = expectedContactManager };

            // ACT
            IPersonEntityDataMapper map = new PersonEntityDataMapper();
            var actual = map.MapPersonDataToPersonEntity(data);

            // ASSERT
            Assert.IsNotNull(actual);
            Assert.AreEqual(expectedId, actual.Id);
            Assert.AreEqual(expectedFirstName, actual.FirstName);
            Assert.AreEqual(expectedLastName, actual.LastName);

            Assert.IsNotNull(actual.Customer);
            Assert.AreEqual(expectedBirthday, actual.Customer.Birthday);
            Assert.AreEqual(expectedEmail, actual.Customer.Email);

            Assert.IsNotNull(actual.Supplier);
            Assert.AreEqual(expectedTelephone, actual.Supplier.Telephone);
            Assert.AreEqual(expectedContactManager, actual.Supplier.ContactManager);
        }
    }
}
