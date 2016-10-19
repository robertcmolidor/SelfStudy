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

        public MultiSelectPage(Dictionary<string, Guid> selectedItems = null)
        {
            if(selectedItems == null)
            selectedItems = new Dictionary<string, Guid>();
            _viewModel = new MultiSelectViewModel();
            _viewModel.SelectedItems = selectedItems;
            BindingContext = _viewModel;

        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            
            

            var selectDaysButton = new Button
            {
                Text = "Select Days"
            };
            selectDaysButton.Clicked += async (o, args) => await OnSelectDaysButtonClicked(o, args);

            var itemsList = new ListView
            {
                VerticalOptions = LayoutOptions.FillAndExpand
            };
            itemsList.SetBinding(ListView.ItemsSourceProperty, "SelectedItems");
            var wrapper = new StackLayout
            {
                VerticalOptions = LayoutOptions.FillAndExpand,
                Children = {selectDaysButton, itemsList}
            };
            Content = wrapper;
        }

        async Task OnSelectDaysButtonClicked(object o, EventArgs e)
        {
            var viewModel = new PickerPageViewModel();
            viewModel.SelectedItems = _viewModel.SelectedItems;
            viewModel.ItemsList = _viewModel.ItemsDictionary;
            await Navigation.PushAsync(new PickerPage(viewModel));
        }
    }
}


