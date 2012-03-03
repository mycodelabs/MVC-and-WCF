using System.IO;

namespace infrasrtucture.contracts
{
    public interface IFileProvider
    {
        Stream GetStreamFromXml();
    }
}