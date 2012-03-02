using System.Collections.Generic;
using System.Xml.Linq;
using domain;

namespace infrasrtucture.contracts
{
    public interface IProviderFactory
    {
        T CreateDocument<T>();
     }
}
