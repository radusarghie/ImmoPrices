using Immo.Database;
using System;
using System.Collections.Generic;
using System.Text;

namespace Immo.Repositories.EF.Base
{
    public class UnitOfWork : IUnitOfWork
    {
        public ImmoContext DBContext { get; }

        public UnitOfWork(ImmoContext context)
        {
            DBContext = context;
        }
        public void Commit()
        {
            DBContext.SaveChanges();
        }

        public void Dispose()
        {
            DBContext.Dispose();

        }
    }
}
