using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TUI.Files.Service.Factory;
using TUI.Files.Service.Models;
using TUI.Files.Service.Strategy;

namespace TUI.Files.Application
{
    public class FileReaderClient
    {
        private string filesDirectoryPath = ConfigurationManager.AppSettings["FilesDirectoryPath"];
        private string encryptedFilesDirectoryPath = ConfigurationManager.AppSettings["EncryptedFilesDirectoryPath"];
        private IFileReaderStrategy fileReaderStrategy;
        private bool useEncryptionSystem;

        public FileReaderClient(IFileReaderFactory factory, bool useEncryptionSystem = false, bool useRoleBasedSecurity = false, string roleName = null)
        {
            this.useEncryptionSystem = useEncryptionSystem;
            fileReaderStrategy = factory.CreateFileReader(useEncryptionSystem, useRoleBasedSecurity, roleName);
        }

        public void Run()
        {
            IEnumerable<FileData> filesData = fileReaderStrategy
                                    .ReadFile(useEncryptionSystem ? encryptedFilesDirectoryPath : filesDirectoryPath);

            StringBuilder sb = new StringBuilder();
            foreach(FileData fileData in filesData)
            {
                sb.AppendLine($"*****************************************************");
                sb.AppendLine($"                  {fileData.Name}                    ");
                sb.AppendLine($"*****************************************************");
                sb.AppendLine();
                sb.AppendLine(fileData.Content);
                sb.AppendLine();
            }

            Console.WriteLine(sb.ToString());
        }
    }
}
