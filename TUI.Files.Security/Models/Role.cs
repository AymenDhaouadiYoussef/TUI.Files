using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TUI.Files.Security.Models
{
    public class Role
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsSysAdmin { get; set; }
        public ICollection<Permission> Permissions { get; set; }
    }
}
