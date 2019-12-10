using System;
using System.Collections.Generic;
using System.Text;

namespace Immo.RepoInterfaces
{
    public interface IRepository<EntityType, EntityIdType>
    {
        void CreateOrUpdate(IEnumerable<EntityType> entities);

        IEnumerable<EntityType> Get(IEnumerable<EntityIdType> ids = null);

        void Delete(IEnumerable<EntityIdType> ids);

        void Save();
    }
}
