using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PapyrusLibrary.Script {
    public enum CallableType {
        Function,
        Fragment,
        Event
    }
    public interface PapyrusICallable {
        bool IsValid();

        CallableType Type { get; }
    }
}
