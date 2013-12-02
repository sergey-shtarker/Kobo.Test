using Kobo.Test.DataContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kobo.Test.Contracts
{
    public interface IPersonBusinessLogic
    {
        long Create(Person person);

        Person Read(long id);

        void Update(Person person);

        void Delete(long id);

        IList<Person> ReadAll();
    }
}
