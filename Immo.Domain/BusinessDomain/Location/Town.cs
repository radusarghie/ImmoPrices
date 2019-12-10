using System;

namespace Immo.Domain.BusinessDomain
{
    public class Town : Entity<Guid>
    {
        public int PostCode { get; set; }

        public string Name { get; set; }

        #region Links
        public Guid ProvinceId { get; set; }

        public Province Province { get; set; }

        #endregion
    }
}
