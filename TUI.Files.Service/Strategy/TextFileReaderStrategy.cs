using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TUI.Files.Service.Models;

namespace TUI.Files.Service.Strategy
{
    public class TextFileReaderStrategy : IFileReaderStrategy
    {
        public IEnumerable<FileData> ReadFile(string directoryPath)
        {
            DirectoryInfo directoryInfo = new DirectoryInfo(directoryPath);
            List<FileData> fileDataCollection = new List<FileData>();
            foreach (FileInfo file in directoryInfo.EnumerateFiles("*.txt", SearchOption.AllDirectories))
            {
                fileDataCollection.Add(new FileData
                {
                    Name = file.Name,
                    Content = File.ReadAllText(file.FullName)
                });
            }

            return fileDataCollection;
        }
    }
}
