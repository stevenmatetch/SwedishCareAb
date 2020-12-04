
using SwedishCareAb.Models;
using SwedishCareAb.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.ApplicationModel.Core;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace SwedishCareAb
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page, INotifyPropertyChanged
    {
        private BookingViewModel bookingViewModel;
        private LoginViewModel loginViewModel;
        public User user { get; set; }
        public MainPageViewModel mainPageViewModel { get; set; }
        public Booking booking { get; set; }
   
      
        //private Booking _selectedBooking { get; set; }

        //public Booking SelectedBooking
        //{
        //    get
        //    {
        //        return  _selectedBooking;
        //    }
        //    set
        //    {
        //        _selectedBooking = value;
        //        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("SelectedBooking"));
        //    }


        //}


        private Booking BOOKING { get; set; }

        public Booking Bookingg
        {
            get
            {
                return BOOKING;
            }
            set
            {
                BOOKING = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Bookingg"));
            }



        }
    

        public void GetBooking(Booking booking)
        {
            /*for (int i = 0; i < bookingViewModel.bookings.Count; i++)
            {
                if (bookingViewModel.bookings[i].Statuss.Equals(booking.Statuss))
                {
                    //bookingViewModel.bookings[i].Statuss = "Ankomstregistrerad";
                    sstatus = "Ankomstregistrerad";
                }
            }*/

            Bookingg = booking;

        }

        public event PropertyChangedEventHandler PropertyChanged;

       
        public MainPage()
        {
            this.InitializeComponent();
            bookingViewModel = new BookingViewModel();
            loginViewModel = new LoginViewModel();
            mainPageViewModel = new MainPageViewModel();
            user = App.LoggedInUser;
            booking = new Booking();
         
        }

       
        private async void Registrera_Click(object sender, RoutedEventArgs e)
        {

            var selected = BookingListView.SelectedItems;

            foreach (Booking booking in selected)
            {


                bool result = await Data.TestServer.Register(booking.ID);

                if (result == true) bookingViewModel.ChangeStatus(booking);

            }

            //BookingListView.Items = bookingViewModel;

        }

        private void BookingListView_ItemClick(object sender, ItemClickEventArgs e)
        {
           
        }

        private void BookingListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var select = BookingListView.SelectedItem;
            if (select != null)
            {
                GetBooking(select as Booking);
              
            }
            

        }

        private void Logout_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(LogginPage));
        }
    }
}
