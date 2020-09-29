using SwedishCareAb.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace SwedishCareAb.ViewModels
{
    public class BookingViewModel
    {
        public ObservableCollection<Booking> bookings { get; set; }
        public Booking MyBooking;

        public BookingViewModel()
        {
          
            bookings = new ObservableCollection<Booking>();
            bookings.Add(new Booking(1, DateTime.Now, "Tandvård", "Bokad"));
            bookings.Add(new Booking(2, DateTime.Now, "Tandvård", "Incheckad"));
            bookings.Add(new Booking(3, DateTime.Now, "Tandvård", "Avbokad"));
        }
        internal void ChangeStatus( Booking booking)
        {
            for (int i = 0; i < bookings.Count; i++)
            {
                if (bookings[i].Statuss.Equals(booking.Statuss))
                {
                    bookings[i].Statuss = "Ankomstregistrerad";
                }
            }
               
            

            //MyBooking.Status = "Ankomstregistrerad";

        }
        //public static bool CheckStatus( Booking booking)
        //{
        //    if (booking.Status == 10)
        //    {
        //        CheckStatus = 

        //    }




        //}


    }
    
    
}
