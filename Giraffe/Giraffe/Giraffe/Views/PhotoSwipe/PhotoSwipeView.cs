using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Giraffe.Content;
using Giraffe.ViewModels.PhotoSwipe;
using Xamarin.Forms;

namespace Giraffe.Views.PhotoSwipe
{
    class PhotoSwipeView : ContentPage
    {
        CardStackView cardStack;
        PhotoSwipeViewModel viewModel = new PhotoSwipeViewModel();
        public PhotoSwipeView()
        {
            Title = "Photo Swipe";
            BackgroundColor = Colors.DefaultBackground;

        }

        protected override void OnAppearing()
        {
            this.BindingContext = viewModel;
            

            RelativeLayout view = new RelativeLayout();

            cardStack = new CardStackView();
            cardStack.SetBinding(CardStackView.ItemsSourceProperty, "ItemsList");
            cardStack.SwipedLeft += SwipedLeft;
            cardStack.SwipedRight += SwipedRight;

            view.Children.Add(cardStack,
                Constraint.Constant(30),
                Constraint.Constant(60),
                Constraint.RelativeToParent((parent) => {
                    return parent.Width - 60;
                }),
                Constraint.RelativeToParent((parent) => {
                    return parent.Height - 140;
                })
            );

            this.LayoutChanged += (object sender, EventArgs e) =>
            {
                cardStack.CardMoveDistance = (int)(this.Width * 0.60f);
            };

            this.Content = view;
        }

        void SwipedLeft(int index)
        {
            // card swiped to the left
        }

        void SwipedRight(int index)
        {
            // card swiped to the right
        }
    }
    
}
