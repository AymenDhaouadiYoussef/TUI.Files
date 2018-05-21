using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TUI.Files.Service.Adapter;
using TUI.Files.Service.Encryption;
using TUI.Files.Service.Strategy;

namespace TUI.Files.Service.Factory
{
    public class JsonFileReaderFactory : IFileReaderFactory
    {
        public IFileReaderStrategy CreateFileReader(bool useEncryptionSystem = false, bool useRoleBasedSecurity = false, string roleName = null)
        {
            IDataEncryptor dataEncryptor = null;
            if (useEncryptionSystem)
                dataEncryptor = new DataEncryptorAdapter();

            return new JsonFileReaderStrategy(useEncryptionSystem, dataEncryptor);
        }
    }
}
