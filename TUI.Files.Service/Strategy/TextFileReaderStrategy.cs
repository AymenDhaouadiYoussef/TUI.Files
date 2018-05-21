using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TUI.Files.Service.Encryption;
using TUI.Files.Service.Models;

namespace TUI.Files.Service.Strategy
{
    public class TextFileReaderStrategy : IFileReaderStrategy
    {
        private readonly bool useEncryptionSystem;
        private readonly IDataEncryptor dataEncryptor;

        public TextFileReaderStrategy(bool useEncryptionSystem = false, IDataEncryptor dataEncryptor = null)
        {
            this.useEncryptionSystem = useEncryptionSystem;
            this.dataEncryptor = dataEncryptor;
        }

        public IEnumerable<FileData> ReadFile(string directoryPath)
        {
            DirectoryInfo directoryInfo = new DirectoryInfo(directoryPath);
            List<FileData> fileDataCollection = new List<FileData>();
            string fileContent;
            foreach (FileInfo file in directoryInfo.EnumerateFiles("*.txt", SearchOption.AllDirectories))
            {
                fileContent = File.ReadAllText(file.FullName);
                fileDataCollection.Add(new FileData
                {
                    Name = file.Name,
                    Content = useEncryptionSystem ? dataEncryptor.Decrypt(fileContent) : fileContent
                });
            }

            return fileDataCollection;
        }
    }
}
