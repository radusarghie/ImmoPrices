using System;
using System.Collections.Generic;
using System.Text;

namespace Immo.Domain.BusinessDomain
{
    public class Province : Entity<Guid>
    {
        public string Name { get; set; }

        #region Links

        public Guid CountryId { get; set; }

        public Country Country { get; set; }

        #endregion

    }
}
