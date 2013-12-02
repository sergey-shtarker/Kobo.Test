using AutoMapper;
using Kobo.Test.MvcApplication.Contracts;
using Kobo.Test.MvcApplication.Models;
using Kobo.Test.MvcApplication.ServiceReference;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Kobo.Test.MvcApplication.ModelBuilders
{
    public class PersonModelBuilder : IPersonModelBuilder
    {
        public IList<PersonItemModel> BuildPersonListModel(IList<Person> personList)
        {
            Mapper.CreateMap<Person, PersonItemModel>();

            IList<PersonItemModel> list = Mapper.Map<IList<Person>, IList<PersonItemModel>>(personList);

            return list;
        }

        public PersonModel BuildPersonModel(Person person)
        {
            Mapper.CreateMap<Supplier, SupplierModel>();
            Mapper.CreateMap<Customer, CustomerModel>();
            Mapper.CreateMap<Person, PersonModel>();

            PersonModel model = Mapper.Map<PersonModel>(person);
            model.CustomerModel = Mapper.Map<CustomerModel>(person.Customer);
            model.SupplierModel = Mapper.Map<SupplierModel>(person.Supplier);

            return model;
        }

        public Person BuildPersonFromModel(PersonModel personModel)
        {
            Mapper.CreateMap<SupplierModel, Supplier>();
            Mapper.CreateMap<CustomerModel, Customer>();
            Mapper.CreateMap<PersonModel, Person>();

            Person person = Mapper.Map<Person>(personModel);
            person.Customer = Mapper.Map<Customer>(personModel.CustomerModel);
            person.Supplier = Mapper.Map<Supplier>(personModel.SupplierModel);

            return person;
        }
    }
}