using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModUtilsLib.Exception
{
    /// <summary>
    /// The exception that is thrown when a mod does not contain a scripts directory.
    /// </summary>
    public class ScriptsDirectoryNotFoundException : System.Exception
    {
        public ScriptsDirectoryNotFoundException() : base()
        {

        }

        public ScriptsDirectoryNotFoundException(string message) : base(message)
        {

        }
    }
}
