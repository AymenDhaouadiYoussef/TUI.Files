using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TUI.Files.Service.Factory;

namespace TUI.Files.Application
{
    class Program
    {
        private const string text = "text";
        private const string xml = "xml";
        private const string json = "json";
        private const string yes = "o";
        private const string no = "n";
        static void Main(string[] args)
        {
            while(true)
            {
                string fileType = null;
                while(fileType != text && fileType != xml && fileType != json)
                {
                    Console.WriteLine("choose a file type (text / xml / json)");
                    fileType = Console.ReadLine();
                }

                string useEncryptionStr = null;
                while (useEncryptionStr != yes && useEncryptionStr != no)
                {
                    Console.WriteLine("do you want to use encryption system ( o / n)");
                    useEncryptionStr = Console.ReadLine();
                }
                bool useEncryption = useEncryptionStr == yes ? true : false;

                string useRoleBasedSecurityStr = null;
                while (useRoleBasedSecurityStr != yes && useRoleBasedSecurityStr != no)
                {
                    Console.WriteLine("do you want to use role based security ( o / n)");
                    useRoleBasedSecurityStr = Console.ReadLine();
                }
                bool useRoleBasedSecurity = useRoleBasedSecurityStr == yes ? true : false;

                string roleName = null;
                if(useRoleBasedSecurity)
                {
                    Console.WriteLine("choose your role name (admin / accountant)");
                    roleName = Console.ReadLine();
                }

                IFileReaderFactory fileReaderFactory = null;
                switch(fileType)
                {
                    case text:
                        fileReaderFactory = new TextFileReaderFactory();
                        break;
                    case xml:
                        fileReaderFactory = new XmlFileReaderFactory();
                        break;
                    case json:
                        fileReaderFactory = new JsonFileReaderFactory();
                        break;
                }

                FileReaderClient client = new FileReaderClient(fileReaderFactory, useEncryption, useRoleBasedSecurity, roleName);
                client.Run();

                Console.WriteLine("do you want to continue ( o / n)");
                string continueStr = Console.ReadLine();
                if (continueStr == no)
                    return;
            }
        }
    }
}
