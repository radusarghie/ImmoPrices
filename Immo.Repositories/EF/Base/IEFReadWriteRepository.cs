using Immo.RepoInterfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Immo.Repositories.EF.Base
{
    public interface  IEFReadWriteRepository<EntityType, EntityIdType> : IReadWriteRepository<EntityType, EntityIdType>
    {
       
    }
}
