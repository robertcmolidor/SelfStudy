using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace PracticeLayouts.Picker
{
    class MultiSelectPage : ContentPage
    {
        private MultiSelectViewModel _viewModel;
        public MultiSelectPage()
        {
            _viewModel = new MultiSelectViewModel();
            BindingContext = _viewModel;

            var selectDaysButton = new Button
            {
                Text = "Select Days"
            };
            selectDaysButton.Clicked += OnSelectDaysButtonClicked;
           
            var itemsList = new ListView
            {
                
            };
           itemsList.SetBinding(ListView.ItemsSourceProperty, "SelectedItems");
            var wrapper = new StackLayout
            {
                Children = {selectDaysButton, itemsList}
            };
            Content = wrapper;



        }

        void OnSelectDaysButtonClicked(object o, EventArgs e)
        {
            var pickerPage = new PickerPage(_viewModel.ItemsDictionary);
            pickerPage.BindingContext = _viewModel;
            Navigation.PushAsync(pickerPage);
        }
    }

}
