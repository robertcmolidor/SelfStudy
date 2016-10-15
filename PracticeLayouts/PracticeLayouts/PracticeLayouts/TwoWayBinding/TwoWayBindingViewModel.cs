using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace PracticeLayouts.TwoWayBinding
{
    class TwoWayBindingViewModel : INotifyPropertyChanged
    {

        public double hue, saturation, luminosity;
        public Color color;


        public event PropertyChangedEventHandler PropertyChanged;   //this does something when properties in the binding context are changed

        public double Hue
        {
            set
            {
                if (hue != value)
                {
                    Hue = value;
                    OnPropertyChanged("Hue");
                    SetNewColor();

                }
            }
            get { return hue; }
        }

        public double Saturation
        {
            set
            {
                if (saturation != value)
                {
                    Saturation = value;
                    OnPropertyChanged("Saturation");
                    SetNewColor();
                }
            }
            get { return saturation; }
        }

        public double Luminosity
        {
            set
            {
                if (luminosity != value)
                {
                    Luminosity = value;
                    OnPropertyChanged("Luminosity");
                    SetNewColor();
                }
            }
            get { return luminosity; }
        }

        public Color Color
        {
            set
            {
                if (color != value)
                {
                    Color = value;
                    OnPropertyChanged("Color");
                    this.Hue = value.Hue;
                    this.Saturation = value.Saturation;
                    this.Luminosity = value.Luminosity;
                }
            }
            get { return Color; }
        }


        void SetNewColor()
        {
            this.Color = Color.FromHsla(this.Hue, this.Luminosity, this.Saturation);
        }



        protected virtual void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }  
        }
    }



}

