using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Giraffe.Content;
using Xamarin.Forms;

namespace Giraffe.Views.Dashboard
{
    class DashBoardView : ContentPage
    {
        public DashBoardView()
        {
            Title = "Giraffe Home";
            BackgroundColor = Colors.DefaultBackground;
            var stack = new StackLayout
            {
                Children =
                {
                    new Label
                    {
                        Text = "DashboardView"
                    }
                }
            };
            Content = stack;
        }

    }
}
