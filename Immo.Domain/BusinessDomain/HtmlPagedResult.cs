using System;
using System.Collections.Generic;
using System.Text;

namespace Immo.Domain.BusinessDomain
{
    public class HtmlPagedResult : Entity<Guid>
    {
        public string Html { get; set; }

        public int PageNumber { get; set; }

        public int PageSize { get; set; }

        #region Links
        public Guid AgencyId { get; set; }

        public PropertyWebsite PropertyWebsite { get; set; }

        #endregion
    }
}
