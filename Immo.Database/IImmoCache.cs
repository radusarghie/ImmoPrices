using Immo.Domain.BusinessDomain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Immo.Database
{
    public interface IImmoCache
    {
        public List<Town> Towns { get; }
        public List<Country> Countries { get; }
        public List<User> Users { get; }
        public List<PropertyWebsite> PropertyWebsites { get; }
    }
}
