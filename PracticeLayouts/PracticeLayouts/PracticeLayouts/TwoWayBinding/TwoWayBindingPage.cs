using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualBasic;
using Xamarin.Forms;

namespace PracticeLayouts.TwoWayBinding
{
    class TwoWayBindingPage : ContentPage
    {

        public TwoWayBindingPage()
        {
            var viewModel = new TwoWayBindingViewModel();
            BindingContext = viewModel;
            viewModel.Color = Color.Blue;

            var colorBox = new BoxView
            {
                VerticalOptions = LayoutOptions.FillAndExpand
            };


            var hue = new Label
            {
                HorizontalOptions = LayoutOptions.Center,
                FormattedText = "Hue = {0:F2}"
            };
            var saturation = new Label
            {
                HorizontalOptions = LayoutOptions.Center,
                FormattedText = "Saturation = {0:F2}"
            };
            var luminosity = new Label
            {
                HorizontalOptions = LayoutOptions.Center,
                FormattedText = "Luminosity = {0:F2}"
            };



            var hueSlider = new Slider { HorizontalOptions = LayoutOptions.FillAndExpand };
            var saturationSlider = new Slider { HorizontalOptions = LayoutOptions.FillAndExpand };
            var luminositySlider = new Slider { HorizontalOptions = LayoutOptions.FillAndExpand };



            hueSlider.SetBinding(Slider.ValueProperty, "Hue", BindingMode.TwoWay);
            saturationSlider.SetBinding(Slider.ValueProperty, "Saturation", BindingMode.TwoWay);
            luminositySlider.SetBinding(Slider.ValueProperty, "Luminosity", BindingMode.TwoWay);

            hue.SetBinding(Label.FormattedTextProperty, "Hue");
            saturation.SetBinding(Label.FormattedTextProperty, "Saturation");
            luminosity.SetBinding(Label.FormattedTextProperty, "Luminosity");

            colorBox.SetBinding(BoxView.ColorProperty, "Color");


            var wrapper = new StackLayout
            {

                Children = { colorBox, hueSlider, hue, saturationSlider, saturation, luminositySlider, luminosity }
            };



            Content  = wrapper;
        }
    }
}
