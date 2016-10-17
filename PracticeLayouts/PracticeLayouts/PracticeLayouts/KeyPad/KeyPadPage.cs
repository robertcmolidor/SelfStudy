using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace PracticeLayouts.KeyPad
{
    class KeyPadPage : ContentPage
    {
        
        public KeyPadPage()
        {
            var viewModel = new KeyPadViewModel();   
            BindingContext = viewModel;                 //bindingContext is inherited.  this means that the ContentPage entirely is set to this viewModel.
                                                        //it is good.  it allows our bindable properties to bind to properties in the viewModel

//these are the 0-9, *,#, and delete buttons.  Notice the command.  we are executing the command interfect for AddCharCommand and passing it the value as a string.  
//if you take a look at the delete button, it calls the DeleteCharCommand which takes nothing and that fires off the viewmodel to shorten the string by one and raise an event
//that the displayText has changed.  The label which is binded to this property will then update itself to show our string. 
#region Buttons
            var one = new Button
            {
                BorderWidth = 0,
                Text = "1",
                Command = new Command(() => viewModel.AddCharCommand.Execute("1"))
            };
            var two = new Button
            {
                BorderWidth = 0,
                Text = "2",
                Command = new Command(() => viewModel.AddCharCommand.Execute("2"))
            };
            var three = new Button
            {
                BorderWidth = 0,
                Text = "3",
                Command = new Command(() => viewModel.AddCharCommand.Execute("3"))
            };
            var four = new Button
            {
                BorderWidth = 0,
                Text = "4",
                Command = new Command(() => viewModel.AddCharCommand.Execute("4"))
            };
            var five = new Button
            {
                BorderWidth = 0,
                Text = "5",
                Command = new Command(() => viewModel.AddCharCommand.Execute("5"))
            };
            var six = new Button
            {
                BorderWidth = 0,
                Text = "6",
                Command = new Command(() => viewModel.AddCharCommand.Execute("6"))
            };
            var seven = new Button
            {
                BorderWidth = 0,
                Text = "7",
                Command = new Command(() => viewModel.AddCharCommand.Execute("7"))
            };
            var eight = new Button
            {
                BorderWidth = 0,
                Text = "8",
                Command = new Command(() => viewModel.AddCharCommand.Execute("8"))
            };

            var nine = new Button
            {
                BorderWidth = 0,
                Text = "9",
                Command = new Command(() => viewModel.AddCharCommand.Execute("9"))
            };
            var zero = new Button
            {
                BorderWidth = 0,
                Text = "0",
                Command = new Command(() => viewModel.AddCharCommand.Execute("0"))
            };
            var star = new Button
            {
                BorderWidth = 0,
                Text = "*",
                Command = new Command(() => viewModel.AddCharCommand.Execute("*"))
            };
            var pound = new Button
            {
                BorderWidth = 0,
                Text = "#",
                Command = new Command(() => viewModel.AddCharCommand.Execute("#"))
            };
            var back = new Button
            {
                BorderWidth = 0,
                Text = "<-",
                Command = new Command(() => viewModel.DeleteCharCommand.Execute(""))
            };
            #endregion 
            var displayLabel = new Label
            {
                TextColor = Color.White
            };
            var keypadFrame = new Frame
            {
                OutlineColor = Color.Accent,
                Content = displayLabel
            };
            var displayGrid = new Grid
            {
                RowDefinitions =
                {
                    new RowDefinition { Height = GridLength.Auto }
                },
                ColumnDefinitions =
                {
                    new ColumnDefinition {Width = new GridLength(1,GridUnitType.Star)},
                    new ColumnDefinition {Width = new GridLength(1,GridUnitType.Auto)}
                },
                Children =
                {
                    {keypadFrame,0,0},
                    {back,1,0 }
                }
            };
            

            var keyPad = new Grid
            {
                VerticalOptions = LayoutOptions.Center,
                RowDefinitions =
                {
                    new RowDefinition {Height = GridLength.Auto},
                    new RowDefinition {Height = GridLength.Auto},
                    new RowDefinition {Height = GridLength.Auto},
                    new RowDefinition {Height = GridLength.Auto},
                    new RowDefinition {Height = GridLength.Auto}
                },
                ColumnDefinitions =
                {
                    new ColumnDefinition {Width = new GridLength(1, GridUnitType.Star)},
                    new ColumnDefinition {Width = new GridLength(1, GridUnitType.Star)},
                    new ColumnDefinition {Width = new GridLength(1, GridUnitType.Star)}

                },
                Children =
                {
                    {displayGrid,0,0},
                    {one,0,1},
                    {two,1,1},
                    {three,2,1},
                    {four,0,2},
                    {five, 1,2},
                    {six,2,2},
                    {seven,0,3},
                    {eight,1,3},
                    {nine,2,3},
                    {star,0,4},
                    {zero,1,4},
                    {pound,2,4}
                }
            };
            
            Grid.SetColumnSpan(displayGrid, 3);  //I thought this was pretty cool.  spanning across a grid.  SetColumnSpan takes the layout, and number of grid sections to span
            displayLabel.SetBinding(Label.TextProperty, "DisplayText");
            /*
             * this is the line that took me hours to figure out.  
             *      1. a view you want to bind a property to
             *      2. setbinding
             *      3.first is the bindable property of this view.  this is the type.whateverproperty.  the type of the owner of the bindable property
             *      4 next is a string matching the property of the viewmodel we're binding to.  this is a string because on property changed just tells
             *          us by string which property changed.
             *      5. for two way binding we can set that in the third property bye sending in a BindingMode.TwoWay.  this tells it to look out for events 
             *          in addition to raising them.  
             */
            


            Content = keyPad;






        }

    }
    
}
