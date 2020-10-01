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
        public Company company { get; set; }

        private int _status { get; set; }
        public int Status
        {
            get { return _status; }
            set
            {
               
                _status = value;
                NotifyPropertyChanged("Status");
                NotifyPropertyChanged("GetStatusText");

                

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
        public string GetBoked
        {

            get
            {
                switch (Status)
                {
                    case 10:
                        return "";
                   
                    default:
                        return "Assets/ckeck.png";
                }

                //if (Status == 10)
                //{
                //      Picture = "";
                //}
                //else
                //{
                //     Picture = "Assets/ckeck.png";
                //}

                //     return "";

            }

        }

        public event PropertyChangedEventHandler PropertyChanged;

        public Booking(int id, DateTime date, string description, int status, string picture, Company comp)
        {
            ID = id;
            Description = description;
            Date = date;
            Status = status;
            Picture = picture;
            company = comp;// new Company("Fålktandvården Skåne ", "Östra Vallgatan 35 C 223 61 Lund", "046-211 80 92", "klinik@kantand.se", "Mån-Tors 7.30-17.00\nFre 7.30 - 13.00 \nAndra tider enligt överenskommelse", "Assets/folktandVården.gif");
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
