using System;
using System.Collections.Generic;
using System.Linq;

namespace Immo.RepoInterfaces
{
    public interface IReadOnlyRepository<EntityType, EntityIdType>
    {
        IEnumerable<EntityType> GetByIds(IEnumerable<EntityIdType> ids);

        EntityType GetById(EntityIdType id);

        IEnumerable<EntityType> GetAll();

        IEnumerable<EntityType> Where(Func<EntityType, bool> predicate);

    }
}
