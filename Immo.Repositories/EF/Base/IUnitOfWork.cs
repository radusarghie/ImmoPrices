using Immo.Database;
using System;

namespace Immo.Repositories.EF.Base
{
    public interface IUnitOfWork : IDisposable
    {
        ImmoContext DBContext { get; }
        void Commit();
    }
}
