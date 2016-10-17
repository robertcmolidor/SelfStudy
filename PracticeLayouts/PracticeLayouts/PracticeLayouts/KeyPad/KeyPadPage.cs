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
            BindingContext = viewModel;

            var one = new Button
            {
                BorderWidth = 0,
                Text = "1",
                CommandParameter = "1"
            };
            var two = new Button
            {
                BorderWidth = 0,
                Text = "2",
                CommandParameter = "2"
            };
            var three = new Button
            {
                BorderWidth = 0,
                Text = "3",
                CommandParameter = "3"
            };
            var four = new Button
            {
                BorderWidth = 0,
                Text = "4",
                CommandParameter = "4"
            };
            var five = new Button
            {
                BorderWidth = 0,
                Text = "3",
                CommandParameter = "5"
            };
            var six = new Button
            {
                BorderWidth = 0,
                Text = "6",
                CommandParameter = "6"
            };
            var seven = new Button
            {
                BorderWidth = 0,
                Text = "7",
                CommandParameter = "7"
            };
            var eight = new Button
            {
                BorderWidth = 0,
                Text = "8",
                CommandParameter = "8"
            };

            var nine = new Button
            {
                BorderWidth = 0,
                Text = "9",
                CommandParameter = "9"
            };
            var zero = new Button
            {
                BorderWidth = 0,
                Text = "0",
                CommandParameter = "0"
            };
            var back = new Button
            {
                BorderWidth = 0,
                Text = "<-"
            };
            var star = new Button
            {
                BorderWidth = 0,
                Text = "*",
                CommandParameter = "*"
            };
            var pound = new Button
            {
                BorderWidth = 0,
                Text = "#",
                CommandParameter = "#"
            };
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
                    new ColumnDefinition { Width = new GridLength(1,GridUnitType.Star)},
                    new ColumnDefinition {Width = new GridLength(1,GridUnitType.Auto) }
                },
                Children =
                {
                    { keypadFrame,0,0},
                    {back,1,0 }
                }
            };
            Grid.SetColumnSpan(keypadFrame, 3);

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
                    { displayGrid,0,0},
                    {one,0,1 },
                    {two,1,1},
                    {three,2,1},
                    {four,0,2 },
                    {five, 1,2},
                    {six,2,2 },
                    {seven,0,3 },
                    {eight,1,3 },
                    {nine,2,3 },
                    {star,0,4 },
                    {zero,1,4 },
                    {pound,2,4 }
                }
            };

            displayLabel.SetBinding(Label.FormattedTextProperty, "DisplayText");

            back.SetBinding(Button.CommandParameterProperty, "DeleteCharCommand");
            one.SetBinding(Button.CommandParameterProperty, "AddCharCommand");
            two.SetBinding(Button.CommandParameterProperty, "AddCharCommand");
            three.SetBinding(Button.CommandParameterProperty, "AddCharCommand");
            four.SetBinding(Button.CommandParameterProperty, "AddCharCommand");
            five.SetBinding(Button.CommandParameterProperty, "AddCharCommand");
            six.SetBinding(Button.CommandParameterProperty, "AddCharCommand");
            seven.SetBinding(Button.CommandParameterProperty, "AddCharCommand");
            eight.SetBinding(Button.CommandParameterProperty, "AddCharCommand");
            nine.SetBinding(Button.CommandParameterProperty, "AddCharCommand");
            zero.SetBinding(Button.CommandParameterProperty, "AddCharCommand");
            star.SetBinding(Button.CommandParameterProperty, "AddCharCommand");
            pound.SetBinding(Button.CommandParameterProperty, "AddCharCommand");


            var wrapper = new StackLayout
            {
                Children = {keyPad}
            };
            Content = wrapper;






        }

    }
    
}
