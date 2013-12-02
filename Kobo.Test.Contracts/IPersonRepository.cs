using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kobo.Test.Contracts
{
    public interface IPersonRepository : IDisposable
    {
        long Create(DataContracts.Person person);

        DataContracts.Person Read(long id);

        void Update(DataContracts.Person person);

        void Delete(long id);

        IList<DataContracts.Person> ReadAll();
    }
}
