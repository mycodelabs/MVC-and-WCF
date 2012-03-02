using System.IO;

namespace infrasrtucture.contracts
{
    public interface IFileProvider
    {
        FileStream GetStreamFromXml(string fileName);
    }
}