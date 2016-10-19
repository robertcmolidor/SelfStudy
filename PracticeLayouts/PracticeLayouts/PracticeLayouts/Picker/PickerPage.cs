using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace PracticeLayouts.Picker
{
    class PickerPage : ContentPage
    {
        private PickerPageViewModel _viewModel;

        
        public PickerPage(PickerPageViewModel input)
        {
            _viewModel = input;
            var okayButton = new Button
            {
                Text = "OK"
            };
            okayButton.Clicked += async (o, args) => await OkayButtonClicked(o, args);
            var wrapper = new StackLayout
            {
                Children = { okayButton}
            };
            foreach (var item in _viewModel.ItemsList)
            {
                wrapper.Children.Add(BuildPickerCell(item));
            }
            Content = wrapper;
        }

        private async Task OkayButtonClicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
            await Navigation.PushAsync(new MultiSelectPage(_viewModel.SelectedItems));
        }

        private StackLayout BuildPickerCell(KeyValuePair<string, Guid> input)
        {
            var cell = new StackLayout();
            var checkedImage = new Image();
            var itemLabel = new Label
            {
                Text = input.Key
            };
            var grid = new Grid
            {
                VerticalOptions = LayoutOptions.Center,
                RowDefinitions =
                {
                    new RowDefinition {Height = new GridLength(40,GridUnitType.Star)},

                },
                ColumnDefinitions =
                {
                    new ColumnDefinition {Width = new GridLength(1, GridUnitType.Star)},
                    new ColumnDefinition {Width = new GridLength(1, GridUnitType.Auto)}

                },
                Children =
                {
                    { itemLabel,0,0},
                    {checkedImage,1,0 }
                }

            };
            var tap = new TapGestureRecognizer();
            tap.Tapped += (s, e) =>
            {
                if (_viewModel.SelectedItems.ContainsValue(input.Value))
                {
                    _viewModel.SelectedItems.Remove(input.Key);
                    checkedImage.Source = "";
                }
                else
                {
                    _viewModel.SelectedItems.Add(input.Key,input.Value);
                    checkedImage.Source = "checkWhite.png";
                }
            };
            if (_viewModel.SelectedItems.ContainsValue(input.Value))
                checkedImage.Source = "checkWhite.png";
            cell.Children.Add(grid);
            cell.GestureRecognizers.Add(tap);
            return cell;

        } 
    }
}
