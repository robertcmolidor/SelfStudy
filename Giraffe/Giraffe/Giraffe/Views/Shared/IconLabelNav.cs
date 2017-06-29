using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Giraffe.Content;
using Xamarin.Forms;

namespace Giraffe.Views.Shared
{
    class IconLabelNav : ContentView
    {
       
        public IconLabelNav(NavigationListItem item)
        {
            var layout = new RelativeLayout
            {
                BackgroundColor = Color.Transparent,
                HeightRequest = 25,
                Padding = new Thickness(0, 0, 0, Layouts.Margin)
            };

            var icon = new Image
            {
                VerticalOptions = LayoutOptions.Start,
                Source = item.Icon,
                Scale = Layouts.IconScale
            };

            layout.Children.Add(icon,
                    Constraint.Constant(Layouts.Margin),
                    Constraint.Constant(Layouts.Margin / 2));

            var value = new Label
            {
                HorizontalOptions = LayoutOptions.StartAndExpand,
                LineBreakMode = LineBreakMode.TailTruncation,
                TextColor = Color.White,
                Text = item.Name,
                FontSize = Fonts.LargeSize
               
            };
            layout.Children.Add(value,
                    Constraint.RelativeToView(icon, (parent, sibling) => sibling.X + sibling.Width + Layouts.Margin),
                    Constraint.RelativeToView(icon, (parent, sibling) => sibling.Y + 1));

            var tapGestureRecognizer = new TapGestureRecognizer();

            tapGestureRecognizer.Tapped += (s, e) =>
            {
                App.NavigatePage(item);
            };
            layout.GestureRecognizers.Add(tapGestureRecognizer);

            Content = layout;
        }
        
    }
}
