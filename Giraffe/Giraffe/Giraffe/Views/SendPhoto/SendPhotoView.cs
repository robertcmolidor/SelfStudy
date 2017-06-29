using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Giraffe.Content;
using Giraffe.ViewModels.SendPhoto;
using Plugin.Media;
using Xamarin.Forms;

namespace Giraffe.Views.SendPhoto
{
    public class SendPhotoView : ContentPage
    {
        SendPhotoViewModel viewModel = new SendPhotoViewModel();

        public SendPhotoView()
        {
            Title = "Photo";
            BackgroundColor = Colors.DefaultBackground;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            BindingContext = viewModel;

            var TakePhotoButton = new Button
            {
                Text = "Take Photo"
            };

            var disclaimer = new Label
            {
                Text = "Your ugly mug is gonna get down voted.  deal with it like a champ and have fun."
            };
            var camera = new Image();




            var stack = new StackLayout
            {
                Spacing = 10,
                Padding = 10,
                Children =
                {
                    TakePhotoButton,
                    disclaimer,
                    camera
                }
            };




            TakePhotoButton.Clicked += async (sender, args) =>
            {

                if (!CrossMedia.Current.IsCameraAvailable || !CrossMedia.Current.IsTakePhotoSupported)
                {
                    DisplayAlert("No Camera", ":( No camera avaialble.", "OK");
                    return;
                }

                var file = await CrossMedia.Current.TakePhotoAsync(new Plugin.Media.Abstractions.StoreCameraMediaOptions
                {

                    Directory = "Sample",
                    Name = "test.jpg"
                });

                if (file == null)
                    return;

                DisplayAlert("File Location", file.Path, "OK");

                camera.Source = ImageSource.FromStream(() =>
                {
                    var stream = file.GetStream();
                    file.Dispose();
                    return stream;
                });
            };
            Content = stack;

        }
    }
}
