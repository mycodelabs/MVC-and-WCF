using System.IO;

namespace infrasrtucture
{
    public class FileProvider : IFileProvider
    {
        public FileStream GetStreamFromXml(string fileName)
        {
            return new FileStream(fileName, FileMode.Open, FileAccess.Read, FileShare.Read);
        }
    }
}