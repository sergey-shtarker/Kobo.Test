using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Kobo.Test.Contracts;
using System.Transactions;

namespace Kobo.Test.DataAccess.Test
{
    [TestClass]
    public class PersonRepositoryTest
    {
        [TestMethod]
        public void PersonRepository_Create_Read()
        {
            // ARRANGE
            string expectedFirstName = "FirstName";
            string expectedLastName = "LastName";
            DateTime? expectedBirthday = new DateTime(2013, 12, 1);
            string expectedEmail = "expectedEmail";
            string expectedTelephone = "Telephone";
            string expectedContactManager = "ContactManager";
 
            DataContracts.Person expectedPerson = new DataContracts.Person { FirstName = expectedFirstName, LastName = expectedLastName };
            expectedPerson.Customer = new DataContracts.Customer { Birthday = expectedBirthday, Email = expectedEmail };
            expectedPerson.Supplier = new DataContracts.Supplier { Telephone = expectedTelephone, ContactManager = expectedContactManager };

            long personId;
            DataContracts.Person actualPerson;

            // ACT
            using (TransactionScope scope = new TransactionScope())
            {
                using (IPersonRepository repo = new PersonRepository())
                {
                    personId = repo.Create(expectedPerson);
                }

                using (IPersonRepository repo = new PersonRepository())
                {
                    actualPerson = repo.Read(personId);
                }
            }

            // ASSERT
            Assert.IsNotNull(actualPerson);
            Assert.IsNotNull(actualPerson.Customer);
            Assert.IsNotNull(actualPerson.Supplier);
        }

        [TestMethod]
        public void PersonRepository_Update()
        {
            // ARRANGE
            string firstName = "FirstName";
            string lastName = "LastName";
            DateTime? birthday = new DateTime(2013, 12, 1);
            string email = "expectedEmail";
            string telephone = "Telephone";
            string contactManager = "ContactManager";

            string updatedFirstName = "updatedFirstName";
            string updatedLastName = "updatedLastName";
            DateTime? updatedBirthday = new DateTime(2014, 12, 1);
            string updatedEmail = "updatedEmail";
            string updatedTelephone = "updated";
            string updatedContactManager = "updatedContactManager";

            DataContracts.Person expectedPerson = new DataContracts.Person { FirstName = firstName, LastName = lastName };
            expectedPerson.Customer = new DataContracts.Customer { Birthday = birthday, Email = email };
            expectedPerson.Supplier = new DataContracts.Supplier { Telephone = telephone, ContactManager = contactManager };

            long personId;
            DataContracts.Person updatedPerson;
            DataContracts.Person actualPerson;

            // ACT
            using (TransactionScope scope = new TransactionScope())
            {
                using (IPersonRepository repo = new PersonRepository())
                {
                    personId = repo.Create(expectedPerson);
                }

                using (IPersonRepository repo = new PersonRepository())
                {
                    updatedPerson = repo.Read(personId);
                }

                updatedPerson.FirstName = updatedFirstName;
                updatedPerson.LastName = updatedLastName;
                updatedPerson.Customer.Birthday = updatedBirthday;
                updatedPerson.Customer.Email = updatedEmail;
                updatedPerson.Supplier.Telephone = updatedTelephone;
                updatedPerson.Supplier.ContactManager = updatedContactManager;

                using (IPersonRepository repo = new PersonRepository())
                {
                    repo.Update(updatedPerson);
                }

                using (IPersonRepository repo = new PersonRepository())
                {
                    actualPerson = repo.Read(personId);
                }
            }

            // ASSERT
            Assert.IsNotNull(actualPerson);
            Assert.IsNotNull(actualPerson.Customer);
            Assert.IsNotNull(actualPerson.Supplier);

            Assert.AreEqual(updatedFirstName, actualPerson.FirstName);
            Assert.AreEqual(updatedEmail, actualPerson.Customer.Email);
            Assert.AreEqual(updatedContactManager, actualPerson.Supplier.ContactManager);
        }
    }
}
