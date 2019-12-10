using System;

namespace Immo.Domain.BusinessDomain
{
    public class User : Entity<Guid>
    {
        public string UserName { get; set; }
    }
}
