using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Immo.Domain.BusinessDomain
{
    public class Town : Entity<Guid>
    {
        public string PostCode { get; set; }

        public string Name { get; set; }

        #region Links

        public Guid CountryId { get; set; }
        public List<Property> Properties { get; set; }

        public List<Search> Searches { get; set; }

        #endregion
    }
}
