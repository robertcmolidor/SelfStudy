using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace PracticeLayouts.KeyPad
{
    class KeyPadViewModel : INotifyPropertyChanged
    {
        private string _inputString = "";                //this holds the local version of input string.  
        private string _displayText = "";                //same for displayText.  this allows us to keep it private, separate from the getters and setters

        private char[] specialChars = {'*', '#'};      //this is used in the formatter to check for * or # on a normal numpad 

        public event PropertyChangedEventHandler PropertyChanged;       //this gets called when either of the two local variables have changed


        public ICommand AddCharCommand { protected set; get; }              //this allows us to add commands to our buttons on the page
        public ICommand DeleteCharCommand { protected set; get; }           //these commands are defined below, they are assigned a "new Command"

        public KeyPadViewModel()    //constructor
        {
            AddCharCommand = new Command<string>(key => { InputString += key; });  //this new command take takes a type of string called key.  we pass key to an anonymous function and it appends key to InputString                                  
            DeleteCharCommand = new Command(                                                            //this new command doesn't take anything.  
                    nothing => { InputString = InputString.Substring(0, InputString.Length - 1); },     //sets InputString to its contents minus 1.  this is essentially dropping the last entry which is being deleted
                    nothing => InputString.Length > 1                                                   // returns true if InputString is bigger than 0
                    );                                                                                  //
        }

        public string InputString                                           //Input string property
        {                                                                   //
            protected set                                                   //protecting the set from outside foes    
            {                                                               //
                if (_inputString == value) return;                           //checking if inputString has changed if not kick out of this
                _inputString = value;                                        //setting inputString to value being passed in
                OnPropertyChanged("InputString");                           //raising a PropertyChanged event that the "InputString" property has changed
                DisplayText = FormatText(_inputString);                      //set DisplayText to the input string (this goes through a formatter to make like phone numbers
                ((Command) DeleteCharCommand).ChangeCanExecute();           //i have no idea what this does.//////////////////////////////////////////////////////////////
            }
            get { return _inputString; }                                      
        }

        public string DisplayText                           //this is the final string that is displayed 
        {
            protected set                                   
            {
                if (_displayText == value) return;           //when setting this we're checking if is't the same as was passed in. if so, bounc out.
                _displayText = value;                        //set displayText to the value being passed in
                OnPropertyChanged("DisplayText");           //raise event that "DisplayText" has changed
            }
            get { return _displayText; }
        }

        

        protected string FormatText(string str) //all this is doing really is putting dashes in to make it look like a phone number.  not explaining it since it's just fancy pants
        {
            var hasNonNumbers = str.IndexOfAny(specialChars) != -1;
            var formatted = str;
            if (hasNonNumbers || str.Length < 4 || str.Length > 10)
            {
            }
            else if (str.Length < 8)
            {
                formatted = String.Format("{0}-{1}", str.Substring(0, 3), str.Substring(3));
            }
            else
            {
                formatted = String.Format("({0}){1}-{2}", str.Substring(0, 3), str.Substring(3, 3), str.Substring(6));
            }
            return formatted;
        }

        protected void OnPropertyChanged(string propertyName)                               //this is implemented from InotifyPropertyChanged.  This allows us to raise events in the case 
        {                                                                                   //one of our properties change.  
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));      //this expression is checking for a null, if not, then it initializes a new instance of the evenchange 
        }                                                                                   //giving it the property name that was changed beit displayText or inputText.  binded properties look 
                                                                                            //for this event to update their own values
    }
}

    
