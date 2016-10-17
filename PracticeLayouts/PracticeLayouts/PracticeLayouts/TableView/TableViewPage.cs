using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace PracticeLayouts.TableView
{
    class TableViewPage : ContentPage
    {

        public TableViewPage()
        {
            //var customCell = new DataTemplate(typeof(MyCell));
            //customCell.SetBinding(MyCell.NameProperty, "Joe Smith");
            //customCell.SetBinding(MyCell.CategoryProperty, "underpants");
            //customCell.SetBinding(MyCell.ImageFilenameProperty, "image");
            
            var table = new Xamarin.Forms.TableView();
            table.HasUnevenRows = true;
            table.Intent = TableIntent.Menu;
            table.Root = new TableRoot
            {
                new TableSection("top level")
                {
                    new MyCell(new MyCellViewModel
                    {
                        Name = "Scotty",
                        Category = "Employee",
                        Description = "Strenths in kicking shit and taking names.",
                        ImageFileName = "one.jpg"
                    })

                },
                new TableSection
                {
                    new TextCell
                    {
                        Text = "another one!"
                    }
                },
                new TableSection
                {
                    new TextCell
                    {
                        Text = "another one!"
                    }
                },
                new TableSection
                {
                    new TextCell
                    {
                        Text = "another one!"
                    }
                },
            };
            Content = table;
        }
        
    }

    public class MyCellViewModel
    {
        public string Name { get; set; }
        public string Category { get; set; }
        public string Description { get; set; }
        public string ImageFileName { get; set; }
    }

    public class MyCell : ViewCell
    {
        //build cell layout, 
        // _________________________
        // |image| name    category|
        // |_____|_description_____|

        

        public MyCell(MyCellViewModel input)
        {
            //instantiate views and set design properties
            var left = new Label
            {
                TextColor = Color.Black
            };
            var right = new Label
            {
                TextColor = Color.Black,
                HorizontalOptions = LayoutOptions.EndAndExpand
            };
            var image = new Image
            {
                Aspect = Aspect.AspectFit
            };
            var description = new Label
            {
                TextColor = Color.Black,
                Opacity = 0.5,
                VerticalOptions = LayoutOptions.EndAndExpand
            };


            //instantiate layouts and set design properties
            var cellWrapper = new StackLayout
            {
                Orientation = StackOrientation.Vertical,
                BackgroundColor = Color.White,
            };
            var horizontalLayout = new StackLayout
            {
                Orientation = StackOrientation.Horizontal,
            };
            //var textLayout = new StackLayout
            //{
            //    Orientation = StackOrientation.Vertical,
            //    HorizontalOptions = LayoutOptions.StartAndExpand,
            //    VerticalOptions = LayoutOptions.StartAndExpand,
            //    HeightRequest = image.MinimumHeightRequest
            //};
            var topRightHalf = new StackLayout
            {
                Orientation = StackOrientation.Horizontal
            };
            var bottomRightHalf = new StackLayout
            {
                Orientation = StackOrientation.Horizontal,
                VerticalOptions = LayoutOptions.EndAndExpand
            };
            var textLayout = new Grid
            {
                RowDefinitions =
                {
                    new RowDefinition {Height = GridLength.Auto},
                    new RowDefinition {Height = GridLength.Auto}
                }
            };


            

            //populate view data
            left.Text = input.Name;
            right.Text = input.Category;
            image.Source = input.ImageFileName;
            description.Text = input.Description;
            
            //add views to layouts
            horizontalLayout.Children.Add(image);
            topRightHalf.Children.Add(left);
            topRightHalf.Children.Add(right);
            bottomRightHalf.Children.Add(description);

            //add layouts to layouts
            textLayout.Children.Add(topRightHalf,0,0);
            textLayout.Children.Add(bottomRightHalf,0,1);
            horizontalLayout.Children.Add(textLayout);

            //wrap in final stacklayout and stuff it in a view
            cellWrapper.Children.Add(horizontalLayout);
            View = cellWrapper;
        }
    }
}