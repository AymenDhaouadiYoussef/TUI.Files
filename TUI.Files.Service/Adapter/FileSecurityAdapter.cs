using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TUI.Files.Security;
using TUI.Files.Security.Models;
using TUI.Files.Service.Security;

namespace TUI.Files.Service.Adapter
{
    public class FileSecurityAdapter : IFileSecurity
    {
        private readonly RoleManager roleManager = new RoleManager();

        public Tuple<bool, IEnumerable<string>> GetRoleFeatures(string roleName)
        {
            Role role = roleManager.GetRoleByName(roleName);
            List<string> permissions = new List<string>();
            if (role.Permissions != null)
                role.Permissions
                    .ToList()
                    .ForEach(p => permissions.Add(p.PermissionDescription));

            return new Tuple<bool, IEnumerable<string>>(role.IsSysAdmin, permissions);
        }
    }
}
