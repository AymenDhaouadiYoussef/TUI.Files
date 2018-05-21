using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TUI.Files.Service.Encryption
{
    public interface IDataEncryptor
    {
        string Encrypt(string plainText, params object[] paramaters);
        string Decrypt(string cipherText, params object[] paramaters);
    }
}
