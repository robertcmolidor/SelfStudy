using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeLayouts.Picker
{
    class MultiSelectViewModel : INotifyPropertyChanged
    {
        //static dictionary holding some items names with matching identifiers
        //its values will be defined in the constructor
        public Dictionary<string,Guid> ItemsDictionary { get; set; }
        
        



        //Bindable Properties
        public event PropertyChangedEventHandler PropertyChanged; 

        private Dictionary<string,Guid> _selectedItems;

        public Dictionary<string,Guid> SelectedItems //we're going to bind our picker view to this property.
        {
            set
            {
                if (_selectedItems != value)
                {
                    _selectedItems = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("SelectedItems"));
                }
            }
            get { return _selectedItems; }
        }

        public MultiSelectViewModel()
        {
            ItemsDictionary = new Dictionary<string, Guid>
            {
                {"Sunday", Guid.NewGuid() },
                {"Monday", Guid.NewGuid() },
                {"Tuesday", Guid.NewGuid() },
                {"Wednesday", Guid.NewGuid() },
                {"Thursday", Guid.NewGuid() },
                {"Friday", Guid.NewGuid() },
                {"Saturday", Guid.NewGuid() }
            };
        }


        protected void OnPropertyChanged(string propertyName)                              
        {                                                                                  
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));      
        }

    }
}
