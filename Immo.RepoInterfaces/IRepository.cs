using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Immo.RepoInterfaces
{
    public interface IRepository<EntityType, EntityIdType>
    {
        void CreateOrUpdate(IEnumerable<EntityType> entities);

        void CreateOrUpdate(EntityType entity);

        IQueryable<EntityType> GetByIds(IEnumerable<EntityIdType> ids);

        EntityType GetById(EntityIdType id);

        IQueryable<EntityType> Where(Func<EntityType, bool> predicate);

        void DeleteByIds(IEnumerable<EntityIdType> ids);

        void DeleteById(EntityIdType id);

        void Delete(IEnumerable<EntityType> entities);

        void Delete(EntityType entitity);

        void Delete(Func<EntityType, bool> predicate);

    }
}
