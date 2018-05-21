using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TUI.Files.Service.Models;

namespace TUI.Files.Service.Strategy
{
    public interface IFileReaderStrategy
    {
        IEnumerable<FileData> ReadFile(string directoryPath);
    }
}
