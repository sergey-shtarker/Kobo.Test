using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kobo.Test.DataContracts;
using Kobo.Test.Entities;

namespace Kobo.Test.Contracts
{
    public interface IPersonEntityDataMapper
    {
        DataContracts.Person MapPersonEntityToPersonData(Entities.Models.Person entity);

        Entities.Models.Person MapPersonDataToPersonEntity(DataContracts.Person data);

        IList<DataContracts.Person> MapPersonEntityListToPersonDataList(IList<Entities.Models.Person> entityList);
    }
}
