using Kobo.Test.MvcApplication.Contracts;
using Kobo.Test.MvcApplication.ModelBuilders;
using Kobo.Test.MvcApplication.Models;
using Kobo.Test.MvcApplication.ServiceReference;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Kobo.Test.MvcApplication.Services
{
    public class PersonModelService : IPersonModelService
    {
        IPersonService _personService;
        IPersonModelBuilder _personModelBuilder;

        public PersonModelService()
        {
            _personService = new PersonServiceClient();
            _personModelBuilder = new PersonModelBuilder();
        }

        public PersonModelService(IPersonService personService, IPersonModelBuilder personModelBuilder)
        {
            _personService = personService;
            _personModelBuilder = personModelBuilder;
        }

        public IList<PersonItemModel> GetPersonItemModelList()
        {
            IList<Person> personList = _personService.ReadAll();

            IList<PersonItemModel> list = _personModelBuilder.BuildPersonListModel(personList);

            return list;
        }

        public PersonModel GetPersonModel(long id)
        {
            Person person = _personService.Read(id);

            PersonModel personModel = _personModelBuilder.BuildPersonModel(person);

            return personModel;
        }

        public void CreatePerson(PersonModel personModel)
        {
            Person person = _personModelBuilder.BuildPersonFromModel(personModel);

            _personService.Create(person);
        }

        public void UpdatePerson(PersonModel personModel)
        {
             Person person = _personModelBuilder.BuildPersonFromModel(personModel);

             _personService.Update(person);
        }

        public void DeletePerson(long id)
        {
            _personService.Delete(id);
        }
    }
}