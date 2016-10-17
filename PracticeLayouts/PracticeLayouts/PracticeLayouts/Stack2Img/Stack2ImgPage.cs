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
            var photoNames = new List<string>{"one.jpeg", "two.jpeg", "three.jpeg", "four.jpeg", "five.jpeg", "six.jpeg", "seven.jpeg", "eight.jpeg", "nine.jpeg", "ten.jpeg" };
            var photoList = new List<Image>();
            foreach (var photo in photoNames)
            {
                var img = new Image
                {
                    Aspect = Aspect.AspectFit,
                    VerticalOptions = LayoutOptions.Center,
                    HorizontalOptions = LayoutOptions.Center,
                    Source = photo
                };
                photoList.Add(img);
            }

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
