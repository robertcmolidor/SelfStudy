using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace PracticeLayouts.Corners
{
    class CornersPage : ContentPage
    {
        public CornersPage()
        {
            var labels = new List<Label>
            {
                new Label {Text = "Top Left" },
                new Label {Text = "Top Right"},
                new Label {Text = "Bottom Right"},
                new Label {Text = "Bottom Left"}
            };

            var layout = new AbsoluteLayout();
            layout.VerticalOptions = LayoutOptions.FillAndExpand;

            
            AbsoluteLayout.SetLayoutFlags(labels[0], AbsoluteLayoutFlags.PositionProportional);
            AbsoluteLayout.SetLayoutBounds(labels[0], new Rectangle(0f, 0f, AbsoluteLayout.AutoSize, AbsoluteLayout.AutoSize));

            AbsoluteLayout.SetLayoutFlags(labels[1],AbsoluteLayoutFlags.PositionProportional);
            AbsoluteLayout.SetLayoutBounds(labels[1], new Rectangle(1f,0f,AbsoluteLayout.AutoSize,AbsoluteLayout.AutoSize));

            AbsoluteLayout.SetLayoutFlags(labels[2], AbsoluteLayoutFlags.PositionProportional);
            AbsoluteLayout.SetLayoutBounds(labels[2], new Rectangle(1f, 1f, AbsoluteLayout.AutoSize, AbsoluteLayout.AutoSize));

            AbsoluteLayout.SetLayoutFlags(labels[3], AbsoluteLayoutFlags.PositionProportional);
            AbsoluteLayout.SetLayoutBounds(labels[3], new Rectangle(0f, 1f, AbsoluteLayout.AutoSize, AbsoluteLayout.AutoSize));

            foreach (var label in labels)
            {
                layout.Children.Add(label);
            }
            
            var stack = new StackLayout();

            stack.Children.Add(layout);
            this.Content = stack;
        }
    }
}
