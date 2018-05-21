using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TUI.Files.Service.Strategy;

namespace TUI.Files.Service.Factory
{
    public interface IFileReaderFactory
    {
        IFileReaderStrategy CreateFileReader(bool useEncryptionSystem = false);
    }
}
