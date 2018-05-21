using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TUI.Files.Service.Encryption;
using TUI.Files.Service.Models;
using TUI.Files.Service.Security;

namespace TUI.Files.Service.Strategy
{
    public class XmlFileReaderStrategy : IFileReaderStrategy
    {
        private readonly bool useEncryptionSystem;
        private readonly IDataEncryptor dataEncryptor;
        private readonly bool useRoleBasedSecurity;
        private readonly string roleName;
        private readonly IFileSecurity fileSecurity;

        public XmlFileReaderStrategy(bool useEncryptionSystem = false, IDataEncryptor dataEncryptor = null, 
            bool useRoleBasedSecurity = false, string roleName = null, IFileSecurity fileSecurity = null)
        {
            this.useEncryptionSystem = useEncryptionSystem;
            this.dataEncryptor = dataEncryptor;

            this.useRoleBasedSecurity = useRoleBasedSecurity;
            this.roleName = roleName;
            this.fileSecurity = fileSecurity;
        }

        public IEnumerable<FileData> ReadFile(string directoryPath)
        {
            DirectoryInfo directoryInfo = new DirectoryInfo(directoryPath);

            Dictionary<string, string> dctPermissions = new Dictionary<string, string>();
            Tuple<bool, IEnumerable<string>> roleFeatures = null;
            if (useRoleBasedSecurity)
            {
                roleFeatures = fileSecurity.GetRoleFeatures(roleName);
                if (!roleFeatures.Item1 && roleFeatures.Item2 != null)
                    roleFeatures.Item2.ToList().ForEach(p => dctPermissions[Path.Combine(directoryInfo.FullName, p)] = null);
            }

            List<FileData> fileDataCollection = new List<FileData>();
            string fileContent;
            foreach (FileInfo file in directoryInfo.EnumerateFiles("*.xml", SearchOption.AllDirectories))
            {
                if(useRoleBasedSecurity && 
                    !roleFeatures.Item1 && 
                    !dctPermissions.ContainsKey(file.FullName))
                    continue;

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
