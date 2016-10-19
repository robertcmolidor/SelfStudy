using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeLayouts.Picker
{
    class PickerPageViewModel
    {
        public Dictionary<string, Guid> ItemsList { get; set; }
        public Dictionary<string, Guid> SelectedItems { get; set; }

        public PickerPageViewModel()
        {
            ItemsList = new Dictionary<string, Guid>();
            SelectedItems = new Dictionary<string, Guid>();
        }
    }
}
