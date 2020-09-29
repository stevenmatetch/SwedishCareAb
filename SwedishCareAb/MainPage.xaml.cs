using SwedishCareAb.Models;
using SwedishCareAb.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
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

        public Booking _selectedBooking { get; set; }

        Booking SelectedBooking
        {
            get
            {
                return  _selectedBooking;
            }
            set
            {
                _selectedBooking = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("SelectedBooking"));
            }


        }

        public event PropertyChangedEventHandler PropertyChanged;

        // private CompanyViewModel companyViewModel;
        public MainPage()
        {
            this.InitializeComponent();
            bookingViewModel = new BookingViewModel();
            //companyViewModel = new CompanyViewModel();
        }

        private void GoBackButton_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(LogginPage));

        }

        

       
      
        private void Registrera_Click(object sender, RoutedEventArgs e)
        {
            var selected = BookingListView.SelectedItems;

            foreach (Booking booking in selected)
            {
                bookingViewModel.ChangeStatus(booking);

            }
        }

        private void BookingListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
          _selectedBooking = BookingListView.SelectedValue as Booking;
        }
    }
}
