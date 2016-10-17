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

            var slider = new Slider //using this as our binding context for the label that tumbles.  this can be any object, really.  its properties are accessed by naming them in a string as shown below
            {
                Maximum = 360,   
                VerticalOptions = LayoutOptions.CenterAndExpand,

            };
            var graphic = new Label
            {
                Text = "Rotation",
                BindingContext = slider,                                //this is the binding context.  this is the object we want to control an aspect of this view.  its property will be defined below
                FontAttributes = FontAttributes.Bold,
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.CenterAndExpand
            };
            var valueLabel = new Label
            {
                BindingContext = slider,                                //same with this.  essentially the slider is going to manipulate a property of each of these views which will be defined with the setbinding line 
                FontAttributes = FontAttributes.Bold,
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.CenterAndExpand
            };
            valueLabel.SetBinding(Label.TextProperty,"Value");          //we're pairing up the bind calling the view's setBinding and passing it a bindable property and a string of the property name
            graphic.SetBinding(Label.RotationProperty, "Value");        //this bindable property is that of the class itself, not the one we created.  in this case, label has a rotation proerty we want to manipulate
            graphic.SetBinding(Label.RotationYProperty, "Value");       //therefore we can pick our properties we want to be controlled by the slider, or reflect the value of the slider.  in this case that value is a propery
            graphic.SetBinding(Label.RotationXProperty,"Value");        //of the slider.


            var wrapper = new StackLayout
            {
                Children = {graphic, slider, valueLabel}
            };

            Content = wrapper;

        }
        }


    }

