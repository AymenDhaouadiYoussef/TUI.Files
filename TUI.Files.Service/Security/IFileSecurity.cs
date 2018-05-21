using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TUI.Files.Service.Security
{
    public interface IFileSecurity
    {
        Tuple<bool, IEnumerable<string>> GetRoleFeatures(string roleName);
    }
}
