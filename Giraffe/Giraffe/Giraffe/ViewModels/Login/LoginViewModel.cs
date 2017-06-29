using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Giraffe.Views;

namespace Giraffe.ViewModels.Login
{
    class LoginViewModel
    {
        public string Username { get; set; }
        public string Password { get; set; }



        public void Login()
        {
            App.Current.MainPage = new MasterView();
        }


    }
}
