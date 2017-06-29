using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Giraffe.Content;
using Xamarin.Forms;


namespace Giraffe.Views.PhotoSwipe
{
    class PhotoCard : ContentView
    {
        public Label Name { get; set; }
        public Image Photo { get; set; }
        public Label Location { get; set; }
        
        

        public PhotoCard()
        {

            RelativeLayout view = new RelativeLayout();

            // box view as the background
            BoxView boxView1 = new BoxView
            {
                Color = Colors.BackGroundAccent,
                InputTransparent = true
            };
            view.Children.Add(boxView1,
                Constraint.Constant(0), Constraint.Constant(0),
                Constraint.RelativeToParent((parent) => {
                    return parent.Width;
                }),
                Constraint.RelativeToParent((parent) => {
                    return parent.Height;
                })
            );

            // items image
            Photo = new Image()
            {
                InputTransparent = true,
                Aspect = Aspect.Fill
            };
            view.Children.Add(Photo,
                Constraint.Constant(0),
                //Constraint.Constant (50),
                Constraint.RelativeToParent((parent) => {
                    double h = parent.Height * 0.80;
                    return ((parent.Height - h) / 2) + 20;
                }),
                Constraint.RelativeToParent((parent) => {
                    return parent.Width;
                }),
                Constraint.RelativeToParent((parent) => {
                    return (parent.Height * 0.80);
                })
            );

            // items label
            Name = new Label()
            {
                TextColor = Color.White,
                FontSize = 22,
                InputTransparent = true
            };
            view.Children.Add(Name,
                Constraint.Constant(10), Constraint.Constant(10),
                Constraint.RelativeToParent((parent) => {
                    return parent.Width;
                }),
                Constraint.Constant(28)
            );

            // location icon
            Image icon = new Image()
            {
                Source = "location.png",
                InputTransparent = true
            };
            view.Children.Add(icon,
                Constraint.Constant(10), Constraint.Constant(40));

            // location description
            Location = new Label()
            {
                TextColor = Color.White,
                FontSize = 14,
                InputTransparent = true
            };
            view.Children.Add(Location,
                Constraint.Constant(30), Constraint.Constant(40),
                Constraint.RelativeToParent((parent) => {
                    return parent.Width;
                }),
                Constraint.Constant(28)
            );

            Image[] stars = new Image[5];

            StackLayout stack = new StackLayout
            {
                Orientation = StackOrientation.Horizontal,
                Spacing = 2
            };

            for (int i = 0; i < 5; i++)
            {
                stars[i] = new Image()
                {
                    Source = "star_on",
                    InputTransparent = true
                };
                stack.Children.Add(stars[i]);
            }

            view.Children.Add(stack,
                Constraint.RelativeToParent((parent) => {
                    return parent.Width - 90;
                }),
                Constraint.Constant(40));

            // bottom label
            
            var bottomSection = new Grid
            {
                VerticalOptions = LayoutOptions.Center,
                HorizontalOptions = LayoutOptions.Center,
                RowDefinitions =
                {
                    new RowDefinition {Height = GridLength.Auto}
                },
                ColumnDefinitions =
                {
                    new ColumnDefinition {Width = new GridLength(1,GridUnitType.Auto)},
                    new ColumnDefinition {Width = new GridLength(1,GridUnitType.Auto)},
                    new ColumnDefinition {Width = new GridLength(1,GridUnitType.Auto)},
                    new ColumnDefinition {Width = new GridLength(1,GridUnitType.Auto)},
                    new ColumnDefinition {Width = new GridLength(1,GridUnitType.Auto)}
                },
                Children =
                {
                    {
                        new Image
                        {
                            Source = Icons.Left
                        },
                        0, 0
                    },
                    {
                        new Image
                        {
                            Source = Icons.ThumbsDown
                        },
                        1, 0
                    },
                    {
                        new Label
                        {
                            Text = "Swipe Left or Right"
                        },
                        2, 0
                    },
                     {
                        new Image
                        {
                            Source = Icons.ThumbsUp
                        },
                        3, 0
                    },
                    {
                        new Image
                        {
                            Source = Icons.Right
                        },
                        4, 0
                    },
                }
            };
            view.Children.Add(
                bottomSection,
                Constraint.Constant(0),
                Constraint.RelativeToParent((parent) => {
                    return parent.Height - 30;
                }),
                Constraint.RelativeToParent((parent) => {
                    return parent.Width;
                }),
                Constraint.Constant(40)
            );
            
            Content = view;


           






        }



    }
}
