using Immo.RepoInterfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Immo.Repositories.EF.Base
{
    public interface  IEFRepository<EntityType, EntityIdType> : IRepository<EntityType, EntityIdType>
    {
       
    }
}
