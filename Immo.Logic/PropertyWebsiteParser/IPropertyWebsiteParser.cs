using Immo.Domain.BusinessDomain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Immo.Logic.PropertyWebsiteParser
{
    public interface IPropertyWebsiteParser
    {
        IEnumerable<Property> SaveProperties(Search search, PropertyWebsite propertyWebsite);

    }
}
