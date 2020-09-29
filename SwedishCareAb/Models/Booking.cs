using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwedishCareAb.Models
{
    public class Booking : INotifyPropertyChanged
    {
        public int ID { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }
        public Company company { get; set; }
        public string Picture { get; set; }


        public event PropertyChangedEventHandler PropertyChanged;


       
        public Booking(int id, DateTime date, string description, string status)
        {
            ID = id;
            Description = description;
            Date = date;
            Status = status;
            company = new Company("Fålktandvården Skåne", "Östra Vallgatan 35 C 223 61 Lund", "046-211 80 92", "klinik@kantand.se", "Mån-Tors 7.30-17.00\nFre 7.30 - 13.00 \nAndra tider enligt överenskommelse", "Assets/folktandVården.gif");
        }
        private void NotifyPropertyChanged(string caller = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(caller));
            }

        }

        public string Statuss
        {
            get { return Status; }
            set
            {
                Status = value;
                NotifyPropertyChanged("Statuss");
            }
        }
        //public string Descriptionn
        //{
        //    get { return Description; }
        //    set
        //    {
        //        Description = value;
        //        NotifyPropertyChanged("Descriptionn");
        //    }
        //}
        //public DateTime Datee
        //{
        //    get { return Date; }
        //    set
        //    {
        //        Date = value;
        //        NotifyPropertyChanged("Datee");
        //    }
        //}

        public string summary

        {
            get { return + ID + "    " + Date  + "    " + Description + "    " + Statuss; }
        }
    }
}
