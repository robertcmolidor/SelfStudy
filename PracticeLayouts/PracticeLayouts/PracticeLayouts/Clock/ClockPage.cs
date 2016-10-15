using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace PracticeLayouts.Clock
{
    class ClockPage : ContentPage
    {

        public ClockPage()
        {
            var viewModel = new ClockViewModel();
            BindingContext = viewModel;

            var clock = new Label
            {
                FormattedText = "{0:T}",
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center
            };
            clock.SetBinding(Label.TextProperty,"DateTime");

            Content = new StackLayout {VerticalOptions = LayoutOptions.FillAndExpand,Children = {clock}};
        }
    }
}
