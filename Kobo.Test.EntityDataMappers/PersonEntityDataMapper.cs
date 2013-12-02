using Kobo.Test.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kobo.Test.DataContracts;
using Kobo.Test.Entities;
using AutoMapper;

namespace Kobo.Test.EntityDataMappers
{
    public class PersonEntityDataMapper : IPersonEntityDataMapper
    {
        public DataContracts.Person MapPersonEntityToPersonData(Entities.Models.Person entity)
        {
            Mapper.CreateMap<Entities.Models.Customer, DataContracts.Customer>();
            Mapper.CreateMap<Entities.Models.Supplier, DataContracts.Supplier>();
            Mapper.CreateMap<Entities.Models.Person, DataContracts.Person>();

            DataContracts.Person data = Mapper.Map<DataContracts.Person>(entity);

            return data;
        }

        public IList<DataContracts.Person> MapPersonEntityListToPersonDataList(IList<Entities.Models.Person> entityList)
        {
            Mapper.CreateMap<Entities.Models.Person, DataContracts.Person>();
            Mapper.CreateMap<Entities.Models.Customer, DataContracts.Customer>();
            Mapper.CreateMap<Entities.Models.Supplier, DataContracts.Supplier>();

            IList<DataContracts.Person> dataList = Mapper.Map<IList<Entities.Models.Person>, IList<DataContracts.Person>>(entityList);

            return dataList;
        }

        public Entities.Models.Person MapPersonDataToPersonEntity(DataContracts.Person data)
        {
            if (data.Customer != null)
            {
                Mapper.CreateMap<DataContracts.Customer, Entities.Models.Customer>();
            }

            if (data.Supplier != null)
            {
                Mapper.CreateMap<DataContracts.Supplier, Entities.Models.Supplier>();
            }

            Mapper.CreateMap<DataContracts.Person, Entities.Models.Person>();

            Entities.Models.Person entity = Mapper.Map<Entities.Models.Person>(data);

            return entity;
        }
    }
}
