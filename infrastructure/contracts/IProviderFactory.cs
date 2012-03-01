using System.Xml.Linq;
using domain;

namespace infrasrtucture.contracts
{
    public interface IProviderFactory
    {
        XDocument CreateDocument();

        T CreateDocument<T>();
     }
}
