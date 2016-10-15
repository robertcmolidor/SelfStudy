using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace PracticeLayouts.ViewBinding
{
    class TumblePage : ContentPage
    {
        public TumblePage()
        {

            var slider = new Slider
            {
                Maximum = 360,
                VerticalOptions = LayoutOptions.CenterAndExpand,

            };
            var graphic = new Label
            {
                Text = "Rotation",
                BindingContext = slider,
                FontAttributes = FontAttributes.Bold,
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.CenterAndExpand
            };
            var valueLabel = new Label
            {
                BindingContext = slider,
                FontAttributes = FontAttributes.Bold,
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.CenterAndExpand
            };
            valueLabel.SetBinding(Label.TextProperty,"Value");
            graphic.SetBinding(Label.RotationProperty, "Value");



            var wrapper = new StackLayout
            {
                Children = {graphic, slider, valueLabel}
            };

            Content = wrapper;

        }
        }


    }

