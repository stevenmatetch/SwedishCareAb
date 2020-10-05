
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
using Windows.UI.Xaml.Documents;

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

            List<User> users = new List<User>();
            users.Add(new User(1, "123", "Steven Komi Matetcho"));
            users.Add(new User(2, "1234", "Daniel Fridhed"));
            users.Add(new User(3, "567", "Peter 'Drutten' Svensson"));

            if (!string.IsNullOrEmpty(UserPersonalIdentityNumber))
            {
                //    User user = new User(1, "123", "Steven Komi Matetcho");

                //User user = users.FirstOrDefault(x => x.PersonalIdentityNumber == UserPersonalIdentityNumber);


                User user = null;
                foreach (var u in users)
                {
                    if (u.PersonalIdentityNumber == UserPersonalIdentityNumber)
                    {
                        user = u;
                        break;
                    }
                }

                if (user!=null)
                {

                    var nav = ServiceLocator.Current.GetInstance<INavigationService>();
                    App.LoggedInUser = user;

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
                
             
        }
    }
}
