using Kobo.Test.BusinessLogic;
using Kobo.Test.Contracts;
using Kobo.Test.DataContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace Kobo.Test.Services
{
    public class PersonService : IPersonService
    {
        IPersonBusinessLogic _personBusinessLogic;

        public PersonService()
        {
            _personBusinessLogic = new PersonBusinessLogic();
        }

        public PersonService(IPersonBusinessLogic personBusinessLogic)
        {
            _personBusinessLogic = personBusinessLogic;
        }

        public long Create(DataContracts.Person person)
        {
            try
            {
                return _personBusinessLogic.Create(person);
            }
            catch (Exception e)
            {
                throw new FaultException<Exception>(e, new FaultReason(e.Message));
            }
        }

        public Person Read(long id)
        {
            try
            {
                return _personBusinessLogic.Read(id);
            }
            catch (Exception e)
            {
                throw new FaultException<Exception>(e, new FaultReason(e.Message));
            }
        }

        public void Update(Person person)
        {
            try
            {
                _personBusinessLogic.Update(person);
            }
            catch (Exception e)
            {
                throw new FaultException<Exception>(e, new FaultReason(e.Message));
            }
        }

        public void Delete(long id)
        {
            try
            {
                _personBusinessLogic.Delete(id);
            }
            catch (Exception e)
            {
                throw new FaultException<Exception>(e, new FaultReason(e.Message));
            }
        }

        public IList<DataContracts.Person> ReadAll()
        {
            try
            {
                return _personBusinessLogic.ReadAll();
            }
            catch (Exception e)
            {
                throw new FaultException<Exception>(e, new FaultReason(e.Message));
            }
        }
    }
}
