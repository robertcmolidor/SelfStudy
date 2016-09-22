using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace PracticeLayouts.Names
{
    public class NamesPage : ContentPage
    {
        Label resultLabel;
        Entry firstName;
        Entry lastName;


        public NamesPage()
        {
            //views
            firstName = new Entry
            {
                Placeholder = "First Name"
            };
            lastName = new Entry
            {
                Placeholder = "Last Name"
            };
            resultLabel = new Label
            {
                Text = ""
            };
            var okayButton = new Button
            {
                Text = "Click Me!"
            };
            okayButton.Clicked += OnOkayButtonClicked;

            this.Content = new StackLayout
            {
                Children =
                {
                    firstName,
                    lastName,
                    resultLabel,
                    okayButton
                }
            };
            




            
        }

        void OnOkayButtonClicked(object sender, EventArgs e)
        {
            resultLabel.Text = "Hello, " + firstName.Text + " " + lastName.Text;
        }
    }
}


