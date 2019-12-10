using System;

namespace Immo.Domain.BusinessDomain
{
    public class PropertyWebsite : Entity<Guid>
    {
        public string WebsiteRootUrl { get; set; }

        public string WebsitePropertyUrl { get; set; }

        public string Name { get; set; }
    }
}
