using System;
using System.Collections.Generic;
using System.Text;

namespace Immo.Domain.BusinessDomain
{
    public class Country : Entity<Guid>
    {
        public string Name { get; set; }

        #region Links

        public List<Town> Towns { get; set; }

        #endregion
    }
}
