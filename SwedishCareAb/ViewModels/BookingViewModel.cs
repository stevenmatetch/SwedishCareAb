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
            bookings.Add(new Booking(1, DateTime.Now, "Tandvård", 10, "Assets/ckeck.png", new Company("Fålktandvården Skåne ", "Östra Vallgatan 35 C 223 61 Lund", "046-211 80 92", "klinik@kantand.se", "Mån-Tors 7.30-17.00\nFre 7.30 - 13.00 \nAndra tider enligt överenskommelse", "Assets/folktandVården.gif")));
            bookings.Add(new Booking(2, DateTime.Now, "Tandvård", 20, "Assets/ckeck.png", new Company("Swedish Care", "Södra Vallgatan 35 C 223 61 Lund", "046-211 80 92", "klinik@kantand.se", "Mån-Tors 7.30-17.00\nFre 7.30 - 13.00 \nAndra tider enligt överenskommelse", "Assets/folktandVården.gif")));
            bookings.Add(new Booking(3, DateTime.Now, "Tandvård", 50, "Assets/ckeck.png", new Company("Stevens Tandvård", "Hemmavid 1 C 223 61 Värnhem", "046-211 80 ", "klinik@kantand.se", "Mån-Tors 7.30-17.00\nFre 7.30 - 13.00 \nAndra tider enligt överenskommelse", "Assets/folktandVården.gif")));
        }
        internal void ChangeStatus( Booking booking)
        {
          

            booking.Statuss = 20;
          
        }
        internal void ChangePicture(Booking booking)
        {


            booking.Picture = "Assets/ckeck.png";

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
