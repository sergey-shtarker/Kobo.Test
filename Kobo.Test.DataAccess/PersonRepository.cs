using Kobo.Test.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kobo.Test.DataContracts;
using Kobo.Test.EntityDataMappers;
using Kobo.Test.Entities.Models;
using System.Data.Entity;

namespace Kobo.Test.DataAccess
{
    public class PersonRepository : IPersonRepository
    {
        IPersonEntityDataMapper _map;
        KoboTestContext _dbContext;

        public PersonRepository()
        {
            _map = new PersonEntityDataMapper();
            _dbContext = new KoboTestContext();
        }

        public long Create(DataContracts.Person person)
        {
            Entities.Models.Person entity = _map.MapPersonDataToPersonEntity(person);
            _dbContext.People.Add(entity);
            _dbContext.SaveChanges();
            return entity.Id;
        }

        public DataContracts.Person Read(long id)
        {
            Entities.Models.Person entity = _dbContext.People
                .Include("Customer")
                .Include("Supplier")
                .Where(person => person.Id == id)
                .FirstOrDefault();

            return _map.MapPersonEntityToPersonData(entity);

        }

        public void Update(DataContracts.Person person)
        {
            Entities.Models.Person entity = _map.MapPersonDataToPersonEntity(person);

            // Attach an entity to the contest and set State to Modified for the whole graph.
            _dbContext.People.Add(entity);

            foreach (var entry in _dbContext.ChangeTracker.Entries())
            {
                entry.State = EntityState.Modified;
            }

            _dbContext.SaveChanges();
        }

        public void Delete(long id)
        {
            Entities.Models.Person entity = _dbContext.People
                .Include("Customer")
                .Include("Supplier")
                .Where(person => person.Id == id)
                .FirstOrDefault();

            foreach (var entry in _dbContext.ChangeTracker.Entries())
            {
                entry.State = EntityState.Deleted;
            }

            _dbContext.SaveChanges();
        }

        public IList<DataContracts.Person> ReadAll()
        {
            IList<Entities.Models.Person> entityList = _dbContext.People.ToList();

            IList<DataContracts.Person> dataList = _map.MapPersonEntityListToPersonDataList(entityList);

            return dataList;
        }

        #region IDisposable

        private bool _disposed = false;

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _dbContext.Dispose();
                }
            }
            _disposed = true;
        }

        #endregion IDisposable
    }
}
