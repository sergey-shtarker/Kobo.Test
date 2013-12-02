using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using Kobo.Test.MvcApplication.ServiceReference;
using Kobo.Test.MvcApplication.Contracts;
using Kobo.Test.MvcApplication.ModelBuilders;
using Kobo.Test.MvcApplication.Models;

namespace Kobo.Test.MvcApplication.Tests.ModelBuilders
{
    [TestClass]
    public class PersonModelBuilderTest
    {
        [TestMethod]
        public void PersonModelBuilder_BuildPersonListModel()
        {
            // ARRANGE
            IList<Person> personList = new List<Person>();
            personList.Add(new Person { Id = 1, FirstName = "FirstName", LastName = "LastName" });

            // ACT
            IPersonModelBuilder personModelBuilder = new PersonModelBuilder();
            IList<PersonItemModel> list = personModelBuilder.BuildPersonListModel(personList);

            // ASSERT
            Assert.IsNotNull(list);
            Assert.AreEqual(1, list.Count);

            Assert.AreEqual(personList[0].Id, list[0].Id);
            Assert.AreEqual(personList[0].FirstName, list[0].FirstName);
            Assert.AreEqual(personList[0].LastName, list[0].LastName);
        }
    }
}
