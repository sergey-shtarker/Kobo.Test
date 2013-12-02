using Kobo.Test.Contracts;
using Kobo.Test.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kobo.Test.BusinessLogic
{
    public class PersonBusinessLogic : IPersonBusinessLogic
    {
        IPersonRepository _personRepository;

        public PersonBusinessLogic()
        {
            _personRepository = new PersonRepository();
        }

        public PersonBusinessLogic(IPersonRepository personRepository)
        {
            _personRepository = personRepository;
        }

        public long Create(DataContracts.Person person)
        {
            return _personRepository.Create(person);
        }

        public DataContracts.Person Read(long id)
        {
            return _personRepository.Read(id);
        }

        public void Update(DataContracts.Person person)
        {
            _personRepository.Update(person);
        }

        public void Delete(long id)
        {
            _personRepository.Delete(id);
        }

        public IList<DataContracts.Person> ReadAll()
        {
            return _personRepository.ReadAll();
        }
    }
}
