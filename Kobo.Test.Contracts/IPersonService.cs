using Kobo.Test.DataContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Kobo.Test.Contracts
{
    [ServiceContract]
    public interface IPersonService
    {
        [OperationContract]
        long Create(Person person);

        [OperationContract]
        Person Read(long id);

        [OperationContract]
        void Update(Person person);

        [OperationContract]
        void Delete(long id);

        [OperationContract]
        IList<Person> ReadAll();
    }
}
