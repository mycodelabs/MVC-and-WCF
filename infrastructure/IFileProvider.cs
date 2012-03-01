using System.IO;

namespace infrasrtucture
{
    public interface IFileProvider
    {
        FileStream GetStreamFromXml(string fileName);
    }
}