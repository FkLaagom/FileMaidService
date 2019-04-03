using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace MaidService
{
    public class Folder
    {
        /// <summary>
        /// Defines The Folder Name
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Defines The Specific Fileformats That The Folder Should Store
        /// </summary>
        public string[] FileFormats { get; set;}
    }
}
