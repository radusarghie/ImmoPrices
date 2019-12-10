using Immo.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Immo.Domain.BusinessDomain
{
    public class Address : Entity<Guid>
    {
        public string Street { get; set; }

        public string Number { get; set; }

        public double? Latitude { get; set; }

        public double? Longitude { get; set; }

        #region Links

        public Guid TownId { get; set; }

        public Town Town { get; set; }
        #endregion
    }
}
