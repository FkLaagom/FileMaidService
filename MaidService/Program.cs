using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using Topshelf;

namespace MaidService
{
    static class Program
    {
        
        private static void Main(string[] targetPath)
        {
            var exitCode = HostFactory.Run(x =>
            {
                x.Service<FileMaid>(s =>
                {
                    s.ConstructUsing(fileMaid => new FileMaid());
                    s.WhenStarted(fileMaid => fileMaid.Start());
                    s.WhenStopped(fileMaid => fileMaid.Stop());
                });

                x.RunAsLocalService();
                x.SetServiceName("FileMaidService");
                x.SetDisplayName("File Maid Service");
                x.SetDescription("A service for reorganizing download folder.");
            });

            int exitCodeValue = (int)Convert.ChangeType(exitCode, exitCode.GetTypeCode());
            Environment.ExitCode = exitCodeValue;
        }

    }
}
