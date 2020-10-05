﻿using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;

namespace SwedishCareAb.Models
{
    public class Booking : INotifyPropertyChanged
    {
        public int ID { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }
        public Company Company { get; set; }

        private int _status { get; set; }
        public int Status
        {
            get { return _status; }
            set
            {
               
                _status = value;
                NotifyPropertyChanged("Status");
                NotifyPropertyChanged("GetStatusText");
                NotifyPropertyChanged("ShowPicture");

            }
        }
        public int Statuss
        {
            get { return Status; }
            set
            {
                
                Status = value;
                NotifyPropertyChanged("Statuss");
            }
        }
        public string GetStatusText
        {

            get
            {

                switch (Status)
                {
                    case 10:
                        return "Bokad";
                    case 20:
                        return "Ankomstregistrerad";
                    default:
                        return "Okänd status";
                }

            }

        }
        public Visibility ShowPicture
        {
            get
            {
                if (Status > 10)
                {
                    return Visibility.Visible;
                }
            
                else
                {
                    return Visibility.Collapsed;
                }
                    
                
            }
        }
        public string _picture { get; set; }


        public string Picture
        {
            get { return _picture; }
            set
            {

                _picture = value;
                NotifyPropertyChanged("Picture");
                NotifyPropertyChanged("GetBoked");

            }
        }
       

        public event PropertyChangedEventHandler PropertyChanged;

        public Booking(int id, DateTime date, string description, int status, string picture, Company company)
        {
            ID = id;
            Description = description;
            Date = date;
            Status = status;
            Picture = picture;
            Company = company;// new Company("Fålktandvården Skåne ", "Östra Vallgatan 35 C 223 61 Lund", "046-211 80 92", "klinik@kantand.se", "Mån-Tors 7.30-17.00\nFre 7.30 - 13.00 \nAndra tider enligt överenskommelse", "Assets/folktandVården.gif");
        }
        private void NotifyPropertyChanged(string caller = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(caller));
            }

        }

        public string summary

        {
            get { return Date + "    " + Description + "    " ; }
        }
    }
}
