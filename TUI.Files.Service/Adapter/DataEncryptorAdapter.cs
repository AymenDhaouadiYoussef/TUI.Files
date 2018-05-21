using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TUI.Files.Encryption;
using TUI.Files.Service.Encryption;

namespace TUI.Files.Service.Adapter
{
    public class DataEncryptorAdapter : IDataEncryptor
    {
        private TuiCustomDataEncryptor dataEncryptor = new TuiCustomDataEncryptor();

        public string Encrypt(string plainText, params object[] paramaters)
        {
            return dataEncryptor.Encrypt(plainText);
        }

        public string Decrypt(string cipherText, params object[] paramaters)
        {
            return dataEncryptor.Decrypt(cipherText);
        }
    }
}
