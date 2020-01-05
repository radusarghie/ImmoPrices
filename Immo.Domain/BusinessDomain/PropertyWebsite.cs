using System;
using System.Collections.Generic;

namespace Immo.Domain.BusinessDomain
{
    public class PropertyWebsite : Entity<Guid>
    {
        public string WebsiteRootUrl { get; set; }

        public string WebsitePropertyUrl { get; set; }

        public string Name { get; set; }

        #region Links

        public List<Property> Properties { get; set; }

        #endregion
    }
}
