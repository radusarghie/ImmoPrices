using System;
using System.Collections.Generic;
using System.Linq;

namespace Immo.RepoInterfaces
{
    public interface IReadWriteRepository<EntityType, EntityIdType>: IReadOnlyRepository<EntityType, EntityIdType>
    {
        void CreateOrUpdate(IEnumerable<EntityType> entities);

        void CreateOrUpdate(EntityType entity);

        void DeleteByIds(IEnumerable<EntityIdType> ids);

        void DeleteById(EntityIdType id);


    }
}
