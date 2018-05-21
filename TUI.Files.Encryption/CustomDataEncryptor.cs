using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TUI.Files.Encryption
{
    public class TuiCustomDataEncryptor
    {
        public string Encrypt(string plainText)
        {
            string encryptedText = new String(plainText.Reverse().ToArray());
            return encryptedText;
        }

        public string Decrypt(string cipherText)
        {
            string decryptedText = new String(cipherText.Reverse().ToArray());
            return decryptedText;
        }
    }
}
