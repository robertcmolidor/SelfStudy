using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace PracticeLayouts.Stack1
{
    public class Stack1Page : ContentPage
    {
        public Stack1Page()
        {
           var labelList = new List<Label>();
            for (int i = 0; i < 50; i++)
            {
                var label = new Label {Text = "This is a Label! " + i};
                labelList.Add(label);
            }



            //stack layout
            var stackLayout = new StackLayout();
            stackLayout.VerticalOptions = LayoutOptions.FillAndExpand;
            stackLayout.Spacing = 0;
            stackLayout.Orientation = StackOrientation.Vertical;

            foreach (var label in labelList)
            {
                stackLayout.Children.Add(label);
            }


            var scrollView = new ScrollView();
            scrollView.Content = stackLayout;


            this.Content = scrollView;
        }
    }
}
