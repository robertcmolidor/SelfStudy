using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Giraffe.Content;
using Giraffe.Views.Dashboard;
using Giraffe.Views.Login;
using Giraffe.Views.PhotoSwipe;
using Giraffe.Views.SendPhoto;
using Giraffe.Views.Shared;
using Xamarin.Forms;

namespace Giraffe.Views
{
    class MainNavigationView : ContentPage
    {
        public MainNavigationView()
        {
            Title = "Menu";
            BackgroundColor = Colors.BackGroundAccent;
            
            



            var homeButton = new IconLabelNav(new NavigationListItem {Icon = Icons.Home, Name = "Home", Page = () => new DashBoardView() });
            var swipeButton = new IconLabelNav(new NavigationListItem { Icon = Icons.TumbsUpDown, Name = "Swipe", Page = () => new PhotoSwipeView() });
            var photoButton = new IconLabelNav(new NavigationListItem {Icon = Icons.AddPhoto, Name = "Send Photo", Page = ()=> new SendPhotoView() });


            var grid = new Grid
            {
                VerticalOptions = LayoutOptions.CenterAndExpand,
                HorizontalOptions = LayoutOptions.Start,
                RowDefinitions =
                {
                    new RowDefinition {Height = GridLength.Auto},
                    new RowDefinition {Height = GridLength.Auto},
                    new RowDefinition {Height = GridLength.Auto},
                    new RowDefinition {Height = GridLength.Auto},
                    new RowDefinition {Height = GridLength.Auto},
                    new RowDefinition {Height = GridLength.Auto},
                },
                ColumnDefinitions =
                {
                    new ColumnDefinition {Width = new GridLength(1, GridUnitType.Auto)},
                },
                Children =
                {

                    {homeButton, 0, 1},
                    {swipeButton, 0, 2},
                    {photoButton, 0, 3}
                    //add more buttons to shit here.  order them with numbers
                },

            };



          
            


            //logout is a different ho.  gotta back all the way out.
            var logoutButton = new IconLabel(Icons.ArrowLeft, "Logout", () => { App.Logout();
                return null;
            });
            logoutButton.VerticalOptions = LayoutOptions.EndAndExpand;

            



            Content = new StackLayout
            {
                Children =
                {
                    grid,
                    logoutButton
                }
            };

        }

    }
}
