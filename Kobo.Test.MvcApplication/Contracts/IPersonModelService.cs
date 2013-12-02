using Kobo.Test.MvcApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kobo.Test.MvcApplication.Contracts
{
    public interface IPersonModelService
    {
        IList<PersonItemModel> GetPersonItemModelList();

        void CreatePerson(PersonModel personModel);

        void UpdatePerson(PersonModel personModel);

        PersonModel GetPersonModel(long id);

        void DeletePerson(long id);
    }
}
