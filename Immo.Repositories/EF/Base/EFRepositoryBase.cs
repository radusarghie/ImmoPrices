using Immo.Database;
using Immo.Domain.BusinessDomain;
using Immo.Repositories.EF;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Immo.Repositories
{
    public abstract class EFRepositoryBase<EntityType, EntityIdType> : IEFRepository<EntityType, EntityIdType> where EntityType : Entity<EntityIdType>
    {
        private readonly ImmoContext dbContext;

        public EFRepositoryBase(ImmoContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public void CreateOrUpdate(IEnumerable<EntityType> entities)
        {
            dbContext.Set<EntityType>().AddRange(entities);
            dbContext.SaveChanges();
        }

        public void CreateOrUpdate(EntityType entity)
        {
            CreateOrUpdate(new List<EntityType> { entity });
        }

        public IQueryable<EntityType> GetByIds(IEnumerable<EntityIdType> ids)
        {
            return dbContext.Set<EntityType>().Where(e => ids.Contains(e.Id));
        }

        public EntityType GetById(EntityIdType id)
        {
            return GetByIds(new List<EntityIdType> { id }).FirstOrDefault();
        }

        public IQueryable<EntityType> Where(Func<EntityType, bool> predicate)
        {
            return dbContext.Set<EntityType>().Where(predicate).AsQueryable<EntityType>();
        }
        public void DeleteByIds(IEnumerable<EntityIdType> ids)
        {
            if (ids.Any())
            {
                var entities = GetByIds(ids);
                if (entities.Any())
                {
                    dbContext.Set<EntityType>().RemoveRange(entities);
                    dbContext.SaveChanges();
                }

            }
        }
        public void DeleteById(EntityIdType id)
        {
            DeleteByIds(new List<EntityIdType> { id });
        }


        public void Delete(IEnumerable<EntityType> entities)
        {
            dbContext.Set<EntityType>().RemoveRange(entities);
            dbContext.SaveChanges();
        }

        public void Delete(EntityType entitity)
        {
            Delete(new List<EntityType> { entitity });
        }
    }
}
