using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PapyrusLibrary.Script;

namespace PapyrusUI.UC {
    public partial class FunctionList : UserControl {

        private const int IMAGELIST_FUNCTION = 0;
        private const int IMAGELIST_FRAGMENT = 1;
        private const int IMAGELIST_EVENT    = 2;

        #region EventHandlers
        public delegate void FunctionAddedEventHandler(PapyrusFunction function);
        public delegate void FunctionRemovedEventHandler(PapyrusFunction function);

        public delegate void FragmentAddedEventHandler(PapyrusFunction fragment);
        public delegate void FragmentRemovedEventHandler(PapyrusFunction function);

        public delegate void EventAddedEventHandler(PapyrusEvent ev);
        public delegate void EventRemovedEventHandler(PapyrusEvent ev);
        #endregion

        #region Events
        public event FunctionAddedEventHandler   FunctionAdded;
        public event FunctionRemovedEventHandler FunctionRemoved;
        #endregion

        public FunctionList() {
            InitializeComponent();
        }

        [Browsable(false)]
        public int Functions { get; private set; } = 0;

        [Browsable(false)]
        public int Fragments { get; private set; } = 0;

        [Browsable(false)]
        public new int Events { get; private set; } = 0;

        public bool HasFunctions { get => Functions > 0; }

        public bool HasFragments { get => Fragments > 0; }

        public bool HasEvents { get => Events > 0; }

        public bool DisplayFunctions {
            get => functionsPanel.Visible;
            set => functionsPanel.Visible = value;
        }
        public bool DisplayFragments {
            get => fragmentsPanel.Visible;
            set => fragmentsPanel.Visible = value;
        }
        public bool DisplayEvents {
            get => eventsPanel.Visible;
            set => eventsPanel.Visible = value;
        }

        [Category("Images"), Browsable(true)]
        public Image FunctionImage {
            get => imageList.Images[IMAGELIST_FUNCTION];
            set => imageList.Images[IMAGELIST_FUNCTION] = value;
        }

        [Category("Images"), Browsable(true)]
        public Image FragmentImage {
            get => imageList.Images[IMAGELIST_FRAGMENT];
            set => imageList.Images[IMAGELIST_FRAGMENT] = value;
        }

        [Category("Images"), Browsable(true)]
        public Image EventImage {
            get => imageList.Images[IMAGELIST_EVENT];
            set => imageList.Images[IMAGELIST_EVENT] = value;
        }

        private bool _update = true;

        public void AddFunction(PapyrusFunction function) {
            if (function.IsFragment())
                return;
                //throw new InvalidCastException($"{function.Name} does not have a valid function signature!");

            string returnType = PapyrusFunction.GetReturnType(function.Data);
            string displayedName = PapyrusFunction.IsProcedure(function.Data) ?
                function.Name : $"{returnType} {function.Name}";
            listview.Items.Add(new ListViewItem(displayedName) { StateImageIndex = IMAGELIST_FUNCTION, ForeColor = Color.White });

            Functions++;

            if(_update) {
                Update();
            }

            FunctionAdded(function);
        }

        public void AddFunctions(PapyrusFunction[] functions) {
            _update = false;
            foreach(PapyrusFunction function in functions) {
                AddFunction(function);
            }

            // Do the updating manually after all functions have been added, and reset it back to normal for subsequent calls that rely on it.
            Update();
            _update = true;
        }
        public void AddFragments(PapyrusFunction[] fragments) {
            _update = false;
            foreach (PapyrusFunction fragment in fragments) {
                AddFragment(fragment);
            }

            // Do the updating manually after all fragments have been added, and reset it back to normal for subsequent calls.
            Update();
            _update = true;
        }
        public void AddEvents(PapyrusEvent[] events) {
            _update = false;
            foreach (PapyrusEvent e in events) {
                AddEvent(e);
            }

            // Do the updating manually after all events have been added, and reset it back to normal for subsequent calls.
            Update();
            _update = true;
        }

        public void AddFragment(PapyrusFunction fragment) {
            if(!fragment.IsFragment())
                throw new InvalidCastException($"{fragment.Name} does not have a valid fragment signature!");

            string displayedName = fragment.Name;
            listview.Items.Add(new ListViewItem(displayedName) { StateImageIndex = IMAGELIST_FRAGMENT, ForeColor = Color.White });

            Fragments++;
            Update();
        }

        public void AddEvent(PapyrusEvent ev) {
            listview.Items.Add(new ListViewItem(ev.Name) { StateImageIndex = IMAGELIST_EVENT, ForeColor = Color.White });

            Events++;
            Update();
        }

        public void Clear() {
            listview.Items.Clear();
            Functions = 0;
            Fragments = 0;
            Events = 0;
            Update();
        }

        private new void Update() {
            if(HasFunctions) {
                DisplayFunctions = true;
                functionsLbl.Text = $"{Functions} {(Functions == 1 ? "Function" : "Functions")}";
                //functionListSeparator.Visible = true;
            }
            else {
                DisplayFunctions = false;
                //functionListSeparator.Visible = false;
            }

            if(HasFragments) {
                DisplayFragments = true;
                fragmentsLbl.Text = $"{Fragments} {(Fragments == 1 ? "Fragment" : "Fragments")}";
                functionListSeparator2.Visible = true; // to be changed into condition below
            }
            else {
                DisplayFragments = false;
                //functionListSeparator2.Visible = false;
            }

            if(HasEvents) {
                DisplayEvents = true;
                eventsLbl.Text = $"{Events} {(Events == 1 ? "Event" : "Events")}";
            }
            else {
                DisplayEvents = false;
            }

            if( HasFunctions && (!HasFragments && !HasEvents) || 
                HasFragments && (!HasFunctions && !HasEvents) ||
                HasEvents    && (!HasFunctions && !HasFragments)) 
            {
                // if there's only one panel to show, there's no need for a separator
                functionListSeparator.Visible = false;
                functionListSeparator2.Visible = false;
            }

            if (HasFunctions && HasFragments || HasFunctions && HasEvents) {
                functionListSeparator2.Visible = true;
            }

            if(HasFragments && HasEvents) {
                functionListSeparator.Visible = true;
            }

            //Console.WriteLine($"Has Functions: {HasFunctions} | Display Functions: {DisplayFunctions} | Functions: {Functions}");
            //Console.WriteLine($"Has Fragments: {HasFragments} | Display Fragments: {DisplayFragments} | Fragments: {Fragments}");
            //Console.WriteLine($"Has Events:    {HasEvents}    | Display Events:    {DisplayEvents}    | Events: {Events}");
            //Console.WriteLine($"functionListSeparator.visible: {functionListSeparator.Visible} | functionListSeparator2.visible: {functionListSeparator2.Visible}");
        }
    }
}
