using Immo.Database;
using Immo.Domain.BusinessDomain;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Immo.Repositories.EF.Base
{
    public class EFReadOnlyRepositoryBase<EntityType, EntityIdType> : IEFReadOnlyRepository<EntityType, EntityIdType> where EntityType : Entity<EntityIdType>
    {
        protected readonly ImmoContext dbContext;

        public EFReadOnlyRepositoryBase(ImmoContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public IEnumerable<EntityType> Where(Func<EntityType, bool> predicate)
        {
            return dbContext.Set<EntityType>().Where(predicate);
        }
     
        public IEnumerable<EntityType> GetByIds(IEnumerable<EntityIdType> ids)
        {
            return Where(e => ids.Contains(e.Id));
        }

        public IEnumerable<EntityType> GetAll()
        {
            return Where(p => true);
        }

        public EntityType GetById(EntityIdType id)
        {
            return GetByIds(new List<EntityIdType> { id }).FirstOrDefault();
        }
   
    }
}
