using Immo.Database;
using Immo.RepoInterfaces;

namespace Immo.Repositories.EF.Base
{
    public interface  IEFReadOnlyRepository<EntityType, EntityIdType> : IReadOnlyRepository<EntityType, EntityIdType>
    {
    }
}
