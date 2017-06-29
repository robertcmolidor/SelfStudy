using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Giraffe.Content;
using Giraffe.ViewModels.Login;
using Xamarin.Forms;

namespace Giraffe.Views.Login
{
    class LoginView : ContentPage
    {
        LoginViewModel viewModel = new LoginViewModel();

        public LoginView()
        {
            Title = " Login";
            BackgroundColor = Colors.DefaultBackground;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            BindingContext = viewModel;

            var username = new Entry();
            username.SetBinding(Entry.TextProperty,"Username");

            var password = new Entry();
            password.SetBinding(Entry.TextProperty,"Password");



            var usernameLabel = new Label
            {
                Text = "Username"
            };
            var passwordLAbel = new Label
            {
                Text = "Password"
            };

            var loginButton = new Button
            {
                Text = "Login"
            };
            loginButton.Clicked += (sender, args) =>
            {
                viewModel.Login();
            };
            var createUserButton = new Button
            {
                Text = "Create"
            };


            var buttonStack = new StackLayout
            {
                Orientation = StackOrientation.Horizontal,
                HorizontalOptions = LayoutOptions.Center,
                Children =
                {
                    loginButton,
                    createUserButton
                }
            };


            var stack = new StackLayout
            {
                Orientation = StackOrientation.Vertical,
                VerticalOptions = LayoutOptions.Center,
                HorizontalOptions = LayoutOptions.Center,
                Children =
                {
                    new StackLayout
                    {
                        BackgroundColor = Colors.DefaultAccentLight,
                        VerticalOptions = LayoutOptions.Center,
                        HorizontalOptions = LayoutOptions.Center,
                        Margin = 10,
                        Padding = 15,
                        Children =
                        {
                            usernameLabel,
                            username,
                            passwordLAbel,
                            password,
                            buttonStack
                        }
                    }
                }
            };





            Content = stack;


        }

    }
}
