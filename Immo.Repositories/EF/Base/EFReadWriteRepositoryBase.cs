using Immo.Database;
using Immo.Domain.BusinessDomain;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Immo.Repositories.EF.Base
{
    public class EFReadWriteRepositoryBase<EntityType, EntityIdType> : EFReadOnlyRepositoryBase<EntityType, EntityIdType>, IEFReadWriteRepository<EntityType, EntityIdType> where EntityType : Entity<EntityIdType>
    {
        public EFReadWriteRepositoryBase(ImmoContext dbContext):base(dbContext)
        {
        }

        public void CreateOrUpdate(IEnumerable<EntityType> entities)
        {
            foreach (var entity in entities)
            {
                if (GetByIds(new List<EntityIdType> { entity.Id })!=null && DbContext.Entry(entity).State != Microsoft.EntityFrameworkCore.EntityState.Detached)
                {
                    DbContext.Entry(entity).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                }
                else 
                {
                    DbContext.Set<EntityType>().AddRange(entities);
                }
            }
          
            DbContext.SaveChanges();
        }

     
        private void Delete(IEnumerable<EntityType> entities)
        {
            DbContext.Set<EntityType>().RemoveRange(entities);
            DbContext.SaveChanges();
        }

        public void DeleteByIds(IEnumerable<EntityIdType> ids)
        {
            if (ids.Any())
            {
                var entities = GetByIds(ids);
                if (entities.Any())
                {
                    Delete(entities);
                }

            }
        }

        public void DeleteById(EntityIdType id)
        {
            DeleteByIds(new List<EntityIdType> { id });
        }

        public void CreateOrUpdate(EntityType entity)
        {
          CreateOrUpdate(new List<EntityType> { entity });
        }
    }
}
