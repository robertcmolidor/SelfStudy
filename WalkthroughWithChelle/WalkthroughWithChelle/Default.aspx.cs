using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WalkthroughWithChelle
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void okButton_Click(object sender, EventArgs e)
        {
            // Wolverine fewest battles
            // Pheonix most battles

            string[] names = new string[] { "Professor X", "Iceman", "Angel", "Beast", "Pheonix", "Cyclops", "Wolverine", "Nightcrawler", "Storm", "Colossus" };
            int[] numbers = new int[] { 7, 9, 12, 15, 17, 13, 2, 6, 8, 13 };

            string result = "";


            //example of a simple for loop
            int smallest = numbers[0];
            int biggest = numbers[0];

            for (int i = 0; i < names.Length; i++)
            {
                if (numbers[i] > biggest)
                    biggest = i;
                else if (numbers[i] < smallest)
                    smallest = i;
            }


            //example of getting the min and max number from an array
            var max = numbers.Max();
            var min = numbers.Min();
            for (int i = 0; i < numbers.Length; i++)
            {
                if (numbers[i] == max)
                    max = i;
                if (numbers[i] == min)
                    min = i;
            }

            //getting the indexes with no loop
            var maxIndex = Array.FindIndex(numbers, x => x == numbers.Max());
            var minIndex = Array.FindIndex(numbers, x => x == numbers.Min());


            //example of a foreach
            int bigIndex = numbers[0];
            int smallIndex = numbers[0];
            foreach (var number in numbers)
            {
                if (number > bigIndex)
                    bigIndex = Array.FindIndex(numbers, x => x == number);
                else if (number < smallIndex)
                    smallIndex = Array.FindIndex(numbers, x => x == number);
            }

            //setting result label using string.format
            result =
                string.Format(
                    "The character with the most wins at {0} is {1}.  The character with the least wins at {2} is {3}",
                    numbers[biggest], names[biggest], numbers[smallest], names[smallest]);



            //setting result label old school way
            result = "The character with the most wind at " + numbers[biggest] + " is " + names[biggest] +". The character with the least wins at " +numbers[smallest] +" is " +names[smallest] +".";






            // Your Code Here!


            resultLabel.Text = result;
        }
    }
}