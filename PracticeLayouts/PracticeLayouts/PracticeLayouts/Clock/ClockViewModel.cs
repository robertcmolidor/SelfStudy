using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace PracticeLayouts.Clock
{
    class ClockViewModel : INotifyPropertyChanged
    {
        private DateTime _dateTime;
        public event PropertyChangedEventHandler PropertyChanged;

        public ClockViewModel()
        {
            DateTime = DateTime.Now;
            Device.StartTimer(TimeSpan.FromSeconds(1), () =>
            {
                DateTime = DateTime.Now;
                return true;
            });
        }

        public DateTime DateTime
        {
            set
            {
                if (_dateTime != value)
                {
                    _dateTime = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("DateTime"));  //null propegation
                }
            }
            get { return _dateTime; }
        }
    }
}
