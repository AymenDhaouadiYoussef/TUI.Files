using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TUI.Files.Service.Models;

namespace TUI.Files.Service.Strategy
{
    public class JsonFileReaderStrategy : IFileReaderStrategy
    {
        public IEnumerable<FileData> ReadFile(string directoryPath)
        {
            DirectoryInfo directoryInfo = new DirectoryInfo(directoryPath);
            List<FileData> fileDataCollection = new List<FileData>();
            string fileContent;
            foreach (FileInfo file in directoryInfo.EnumerateFiles("*.json", SearchOption.AllDirectories))
            {
                fileContent = File.ReadAllText(file.FullName);
                fileDataCollection.Add(new FileData
                {
                    Name = file.Name,
                    Content = fileContent
                });
            }

            return fileDataCollection;
        }
    }
}
