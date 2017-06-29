using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Giraffe.Views.PhotoSwipe;

namespace Giraffe.ViewModels.PhotoSwipe
{
    class PhotoSwipeViewModel
    {
        public event PropertyChangedEventHandler PropertyChanged;

        List<CardStackView.Item> items = new List<CardStackView.Item>();
        public List<CardStackView.Item> ItemsList
        {
            get
            {
                return items;
            }
            set
            {
                if (items == value)
                {
                    return;
                }
                items = value;
                OnPropertyChanged();
            }
        }

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        protected virtual void SetProperty<T>(ref T field, T value, [CallerMemberName] string propertyName = null)
        {
            field = value;
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public PhotoSwipeViewModel()
        {
            items.Add(new CardStackView.Item() { Name = "Pizza to go", Photo = "http://placebear.com/300/200", Location = "30 meters away"});
            items.Add(new CardStackView.Item() { Name = "Dragon & Peacock", Photo = "http://placebear.com/300/200", Location = "800 meters away"});
            items.Add(new CardStackView.Item() { Name = "Murrays Food Palace", Photo = "http://placebear.com/300/200", Location = "9 miles away"});
            items.Add(new CardStackView.Item() { Name = "Food to go", Photo = "http://placebear.com/300/200", Location = "4 miles away"});
            items.Add(new CardStackView.Item() { Name = "Mexican Joint", Photo = "http://placebear.com/300/200", Location = "2 miles away" });
            items.Add(new CardStackView.Item() { Name = "Mr Bens", Photo = "http://placebear.com/300/200", Location = "1 mile away" });
            items.Add(new CardStackView.Item() { Name = "Corner Shop", Photo = "http://placebear.com/300/200", Location = "100 meters away" });
            items.Add(new CardStackView.Item() { Name = "Sarah's Cafe", Photo = "http://placebear.com/300/200", Location = "6 miles away" });
            items.Add(new CardStackView.Item() { Name = "Pata Place", Photo = "http://placebear.com/300/200", Location = "2 miles away" });
            items.Add(new CardStackView.Item() { Name = "Jerrys", Photo = "http://placebear.com/300/200", Location = "8 miles away"});
        }
    }
}
