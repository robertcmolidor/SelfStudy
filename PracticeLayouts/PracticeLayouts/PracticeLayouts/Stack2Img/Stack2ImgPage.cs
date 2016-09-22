using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace PracticeLayouts.Stack2Img
{
    class Stack2ImgPage : ContentPage
    {
        public Stack2ImgPage()
        {
            var photoList = new List<Image>
            {
                 new Image {
                     Aspect = Aspect.AspectFit,
                     VerticalOptions = LayoutOptions.Center,
                     HorizontalOptions = LayoutOptions.Center,
                     Source = @"one.jpeg"},
                 new Image {
                     Aspect = Aspect.AspectFit,
                     VerticalOptions = LayoutOptions.Center,
                     HorizontalOptions = LayoutOptions.Center,
                     Source = @"two.jpeg"},
                 new Image {
                     Aspect = Aspect.AspectFit,
                     VerticalOptions = LayoutOptions.Center,
                     HorizontalOptions = LayoutOptions.Center,
                     Source = @"three.jpeg"},
                 new Image {
                     Aspect = Aspect.AspectFit,
                     VerticalOptions = LayoutOptions.Center,
                     HorizontalOptions = LayoutOptions.Center,
                     Source = @"four.jpeg"},
                 new Image {
                     Aspect = Aspect.AspectFit,
                     VerticalOptions = LayoutOptions.Center,
                     HorizontalOptions = LayoutOptions.Center,
                     Source = @"five.jpeg"},
                 new Image {
                     Aspect = Aspect.AspectFit,
                     VerticalOptions = LayoutOptions.Center,
                     HorizontalOptions = LayoutOptions.Center,
                     Source = @"six.jpeg"},
                 new Image {
                     Aspect = Aspect.AspectFit,
                     VerticalOptions = LayoutOptions.Center,
                     HorizontalOptions = LayoutOptions.Center,
                     Source = @"seven.jpeg"},
                 new Image {
                     Aspect = Aspect.AspectFit,
                     VerticalOptions = LayoutOptions.Center,
                     HorizontalOptions = LayoutOptions.Center,
                     Source = @"eight.jpeg"},
                 new Image {
                     Aspect = Aspect.AspectFit,
                     VerticalOptions = LayoutOptions.Center,
                     HorizontalOptions = LayoutOptions.Center,
                     Source = @"nine.jpeg"},
                 new Image {
                     Aspect = Aspect.AspectFit,
                     VerticalOptions = LayoutOptions.Center,
                     HorizontalOptions = LayoutOptions.Center,
                     Source = @"ten.jpeg"},
            };

            var stack = new StackLayout();
            stack.VerticalOptions = LayoutOptions.FillAndExpand;
            stack.Spacing = 2;
            stack.Orientation = StackOrientation.Horizontal;

            foreach (var photo in photoList)
            {
                stack.Children.Add(photo);
            }

            var scroll = new ScrollView();
            scroll.Content = stack;
            scroll.Orientation = ScrollOrientation.Horizontal;
            this.Content = scroll;

        }
    }
}
