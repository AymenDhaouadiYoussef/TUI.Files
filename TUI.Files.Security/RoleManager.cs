using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TUI.Files.Security.Models;

namespace TUI.Files.Security
{
    public class RoleManager
    {
        private readonly List<Role> roles;

        public RoleManager()
        {
            List<Permission> permissions = new List<Permission>
            {
                new Permission() {PermissionDescription = "file1.txt" },
                new Permission() {PermissionDescription = "file1.xml" },
                new Permission() {PermissionDescription = "file1.json" },

                new Permission() {PermissionDescription = "accountant\\file1.txt" },
                new Permission() {PermissionDescription = "accountant\\file1.xml" },
                new Permission() {PermissionDescription = "accountant\\file1.json" }
            };

            roles = new List<Role> {
                new Role() {Name = "admin", IsSysAdmin = true },
                new Role() {Name = "accountant", IsSysAdmin = false,
                            Permissions = new List<Permission> { permissions[3], permissions[4],permissions[5]}}
            };
        }

        public Role GetRoleByName(string name)
        {
            Role role = (from r in roles
                         where r.Name == name
                         select r).FirstOrDefault();

            return role;
        }
    }
}
