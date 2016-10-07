using System;
using Xamarin.Forms;

namespace HelloXamarin
{
    public class HelloXamarinPage : ContentPage
    {
        public HelloXamarinPage()
        {
            Content = new Label
            {
                Text = "Hi there.",
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center,
                FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label)),
                FontAttributes = FontAttributes.Bold | FontAttributes.Italic
            };


            //device.onplatform allows OS specific settigs in order ios, android, winphone, lastly default
            Padding = Device.OnPlatform<Thickness>( new Thickness(0, 20, 0, 0),
                                                    new Thickness(0),
                                                    new Thickness(0));

            //to specify just one os, the neatest way is:
            Device.OnPlatform(iOS: () =>
            {
                Padding = new Thickness(0, 20, 0, 0);
            });



        }
    }
}
