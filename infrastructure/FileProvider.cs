using System.Configuration;
using System.IO;
using infrasrtucture.contracts;

namespace infrasrtucture
{
    public class FileProvider : IFileProvider
    {
        static string xmlFileName;

        static FileProvider()
        {
            xmlFileName = ConfigurationManager.AppSettings["xmlFileName"];
        }

        public Stream GetStreamFromXml()
        {
            return new FileStream(xmlFileName, FileMode.Open, FileAccess.Read, FileShare.Read);
        }
    }
}