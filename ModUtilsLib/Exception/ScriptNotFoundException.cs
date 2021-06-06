using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModUtilsLib.Exception
{
    /// <summary>
    /// The exception that is thrown when an attempt to access a script from a specified mod does not exist.
    /// </summary>
    public class ScriptNotFoundException : System.Exception
    {
        public ScriptNotFoundException() : base()
        {

        }

        public ScriptNotFoundException(string message) : base(message)
        {

        }
    }
}
