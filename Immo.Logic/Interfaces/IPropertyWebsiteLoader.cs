using Immo.Domain.BusinessDomain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Immo.Logic.Interfaces
{
    public interface IPropertyWebsiteDataImporter
    {
        void Import(PropertyWebsite propertyWebsite);
    }
}
