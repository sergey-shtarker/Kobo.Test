using Kobo.Test.MvcApplication.Models;
using Kobo.Test.MvcApplication.ServiceReference;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kobo.Test.MvcApplication.Contracts
{
    public interface IPersonModelBuilder
    {
        IList<PersonItemModel> BuildPersonListModel(IList<Person> personList);

        PersonModel BuildPersonModel(Person person);

        Person BuildPersonFromModel(PersonModel personModel);
    }
}
