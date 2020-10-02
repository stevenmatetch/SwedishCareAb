
using SwedishCareAb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public LoginViewModel()
        {
           
            userViewModel = new UserViewModel();
        }
       internal void Login()
       {
            User user = new User(1,"123", "Steven Komi Matetcho");
            //var user = userViewModel.GetUser(userUserPersonalIdentityNumber)
            if(user.ID != 0)
            {
                App.LoggedInUser = user;

            }
            else
            {
                var dialog = new ContentDialog1();
                var result = dialog.ShowAsync();
            }
        }
    }
}
