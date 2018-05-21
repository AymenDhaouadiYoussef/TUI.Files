﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TUI.Files.Service.Adapter;
using TUI.Files.Service.Security;
using TUI.Files.Service.Strategy;

namespace TUI.Files.Service.Factory
{
    public class XmlFileReaderFactory : IFileReaderFactory
    {
        public IFileReaderStrategy CreateFileReader(bool useEncryptionSystem = false, bool useRoleBasedSecurity = false, string roleName = null)
        {
            IFileSecurity fileSecurity = null;
            if (useRoleBasedSecurity)
                fileSecurity = new FileSecurityAdapter();
            return new XmlFileReaderStrategy(useRoleBasedSecurity, roleName, fileSecurity);
        }
    }
}
