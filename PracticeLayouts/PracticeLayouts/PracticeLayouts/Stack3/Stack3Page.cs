using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace PracticeLayouts.Stack3
{
    class Stack3Page : ContentPage
    {
        public Stack3Page()
        {
            var stack = new StackLayout();
            var grids = new List<Grid>();

            for (int i = 0; i < 30; i++)
            {
                var grid = new Grid
                {
                    VerticalOptions = LayoutOptions.Center,
                    RowDefinitions =
                    {
                        new RowDefinition {Height = GridLength.Auto}
                    },
                    ColumnDefinitions =
                    {
                        new ColumnDefinition {Width = new GridLength(1, GridUnitType.Star)},
                        new ColumnDefinition {Width = new GridLength(1, GridUnitType.Star)},
                        new ColumnDefinition {Width = new GridLength(1, GridUnitType.Star)}
                    }
                };
                grid.Children.Add(new Label {Text = "Label 1", HorizontalTextAlignment = TextAlignment.Start}, 0, 0);
                grid.Children.Add(new Label {Text = "Label 2", HorizontalTextAlignment = TextAlignment.Center}, 1, 0);
                grid.Children.Add(new Label {Text = "Label 3", HorizontalTextAlignment = TextAlignment.End}, 2, 0);
                grids.Add(grid);
            }

            foreach (var grid in grids)
            {
                stack.Children.Add(grid);
            }

            var scroll = new ScrollView();

            scroll.Content = stack;
            scroll.Padding = new Thickness(10);
            this.Content = scroll;
        }
    }
}
