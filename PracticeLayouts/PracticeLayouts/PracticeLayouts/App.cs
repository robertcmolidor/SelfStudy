using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;
using PracticeLayouts.Names;
using PracticeLayouts.Stack1;
using PracticeLayouts.Stack2Img;
using PracticeLayouts.Corners;
using PracticeLayouts.Stack3;

namespace PracticeLayouts
{
	public class App : Application
	{
        public App()
        {
            var tabs = new TabbedPage { Title = "Practice Layouts" };
            tabs.Children.Add(new NamesPage { Title = "Names"});
            tabs.Children.Add(new Stack1Page { Title = "Stack 1" });
            tabs.Children.Add(new Stack2ImgPage { Title = "Stack 2" });
            tabs.Children.Add(new CornersPage { Title = "Corners" });
            tabs.Children.Add(new Stack3Page { Title = "Stack 3" });

            MainPage = tabs;
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
	}
}
