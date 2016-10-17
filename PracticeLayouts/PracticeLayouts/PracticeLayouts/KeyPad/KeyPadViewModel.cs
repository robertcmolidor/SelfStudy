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
        string inputString = "";
        string displayText = "";
        char[] specialChars = {'*', '#'};

        public event PropertyChangedEventHandler PropertyChanged;

        public KeyPadViewModel()
        {
            this.AddCharCommand = new Command<string>((key) => { this.InputString += key; });
            this.DeleteCharCommand =
                new Command(
                    (nothing) => { this.InputString = this.InputString.Substring(0, this.InputString.Length - 1); },
                    (nothing) => { return this.InputString.Length > 0; });
        }

        public string InputString
        {
            protected set
            {
                if (inputString != value)
                {
                    inputString = value;
                    OnPropertyChanged("InputString");
                    this.DisplayText = FormatText(inputString);
                    ((Command) this.DeleteCharCommand).ChangeCanExecute();
                }
            }
            get { return inputString; }
        }

        public string DisplayText
        {
            protected set
            {
                if (displayText != value)
                {
                    displayText = value;
                    OnPropertyChanged("DsiplayText");
                }
            }
            get { return displayText; }
        }

        public ICommand AddCharCommand { protected set; get; }
        public ICommand DeleteCharCommand { protected set; get; }

        protected string FormatText(string str)
        {
            bool hasNonNumbers = str.IndexOfAny(specialChars) != -1;
            string formatted = str;
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

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}

    
