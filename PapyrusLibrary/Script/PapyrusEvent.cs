using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PapyrusLibrary.Script {
    public class PapyrusEvent {
        public string Data { get; private set; }
        public string Name { get; private set; }
        public PapyrusEvent(string eventLine) {
            Data = eventLine;
            string eventName = eventLine.Replace("event", "").
                                         Replace("Event", "").Trim();
            Name = eventName;
        }

        // TODO: Check whether or not the event is inside a state
        public static PapyrusEvent[] GetEvents(ScriptInfo script) {
            List<PapyrusEvent> events = new List<PapyrusEvent>();
            foreach(string line in script.Data) {
                if(IsValidEvent(line)) {
                    events.Add(new PapyrusEvent(line));
                }
            }
            return events.ToArray();
        }

        private static bool IsValidEvent(string eventLine) {
            try {
                string fw = eventLine.Substring(0, eventLine.IndexOf(' ')+1);
                return string.Equals(fw, "Event ", StringComparison.OrdinalIgnoreCase);
            }
            catch (Exception) {

                
            }
            return eventLine.ToLower().Contains("event ") &&
                   !eventLine.ToLower().Contains("endevent") &&
                   !eventLine.ToLower().Contains("sendmodevent") &&
                   !eventLine.ToLower().Contains("registerformod") &&
                   !eventLine.Contains(';');
        }
    }
}
