using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Giraffe.Content
{
    public static class Layouts
    {
        public static double Margin => 16;
        public static int CardSpacing => 15;


        public static Thickness ModalPadding => new Thickness(0, Device.OnPlatform(20, 0, 0), 0, 0);
        public static Thickness ScrollViewPadding => new Thickness(10);
        public static Thickness ListCellPaddingSingleLine => new Thickness(10);
        public static Thickness ListCellPaddingTwoLine => new Thickness(5);
        public static Thickness ListWrapperPadding => new Thickness(0, 0, 10, 0);


        //list grid column spacing
        public static GridLength IconSpacing => new GridLength(.1, GridUnitType.Star);
        public static GridLength PrimaryContentSpacing => new GridLength(1, GridUnitType.Star);
        public static GridLength SecondaryContentSpacing => new GridLength(.4, GridUnitType.Star);
        public static GridLength HeaderIconSpacing => new GridLength(.128, GridUnitType.Star);
        public static GridLength HeaderPrimarySpacing => new GridLength(1, GridUnitType.Star);
        public static GridLength HeaderSecondarySpacing => new GridLength(.45, GridUnitType.Star);

        public static double IconScale = 1;


        public static BoxView Separator
            => new BoxView() { Color = Colors.Separator, WidthRequest = 100, HeightRequest = 1, }; //Opacity = 0.5 };



    }
}
