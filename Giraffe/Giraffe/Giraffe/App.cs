using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Giraffe.Content;
using Giraffe.Views;
using Giraffe.Views.Dashboard;
using Giraffe.Views.Login;
using Giraffe.Views.Shared;
using Xamarin.Forms;


namespace Giraffe
{
    public partial class App : Application
    {
        public static MasterDetailPage MasterDetailPage { get; set; }
        public static INavigation Navigation { get; set; }

        public App()
        {
          
            MainPage = new LoginView();
            
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
        public static void NavigatePage(NavigationListItem item)
        {
            //todo:add logic to check for network connection and stey put if none
            if (item == null) return;

            var page = item.Page();

            if (page == null)
            {
                Device.BeginInvokeOnMainThread(() =>
                {
                    Current.MainPage.DisplayAlert(item.Name, "Coming Soon!", "OK");
                });
                return;
            }

            var navigationPage = new NavigationPage(page);

            if (((NavigationPage)MasterDetailPage.Detail).CurrentPage.GetType() ==
                navigationPage.CurrentPage.GetType()) return;

            

            item.IsSelected = true;

            navigationPage.BarBackgroundColor = Colors.BackGroundAccent;
            navigationPage.BarTextColor = Colors.DefaultTextColor;

            MasterDetailPage.Detail = navigationPage;
            Navigation = MasterDetailPage.Detail.Navigation;
            MasterDetailPage.IsPresented = false;
        }
        public static void Logout()
        {
            App.Current.MainPage = new LoginView();
        }
    }
    
}
