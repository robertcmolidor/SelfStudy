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
        private Dictionary<string, Guid> Selected;
        
        public PickerPage(Dictionary<string, Guid> input)
        {
            
            var wrapper = new StackLayout();

            foreach (var item in input)
            {
                
            }
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
                    new RowDefinition {Height = GridLength.Auto},

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
            tap.Tapped += (s, e) => {
                
            };
            cell.Children.Add(grid);


            return cell;

        } 
    }
}
