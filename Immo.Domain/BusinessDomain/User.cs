using System;
using System.Collections.Generic;

namespace Immo.Domain.BusinessDomain
{
    public class User : Entity<Guid>
    {
        public string UserName { get; set; }

        #region Links

        public List<Search> Searches { get; set; }

        #endregion
    }
}
