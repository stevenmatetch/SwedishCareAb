
using CommonServiceLocator;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Views;
using SwedishCareAb.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SwedishCareAb.ViewModels
{
    public class LoginViewModel
    {
        public UserViewModel userViewModel;
        public string _UserPersonalIdentityNumber { get; set; }
  
        public string UserPersonalIdentityNumber
        {
            get => _UserPersonalIdentityNumber;
            set => _UserPersonalIdentityNumber = value;
        }
        public ICommand LoginBtn { get; set; }
        public LoginViewModel()
        {
            LoginBtn = new RelayCommand(Login);
            userViewModel = new UserViewModel();
           
        }
       internal void Login()
       {
            User user = new User(1, "123", "Steven Komi Matetcho");

            if (!string.IsNullOrEmpty(UserPersonalIdentityNumber))
            {
               

                if (user.PersonalIdentityNumber == "123")
                {

                    var nav = ServiceLocator.Current.GetInstance<INavigationService>();
                    nav.NavigateTo(App.MainPage);

                }
                else 
                {
                    ContentDialog1 c = new ContentDialog1();
                    _= c.ShowAsync();
                    //var dialog = new ContentDialog1();
                    //var result = dialog.ShowAsync();
                }



            }
                //var user = userViewModel.GetUser(userUserPersonalIdentityNumber)
             
        }
    }
}
